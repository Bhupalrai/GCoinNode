using Microsoft.AspNetCore.Mvc;

using GcoinNode.Data.impl;
using GcoinNode.Dtos;
using AutoMapper;
using System.Collections.Generic;
using GcoinNode.Models;
using GcoinNode.Data;

namespace GcoinNode.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionRepo _repository;
        private readonly IMapper _mapper;

        public TransactionController(ITransactionRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<TransactionReadDto>> GetAllTransactions()
        {
            var transacionItem = _repository.GetAllTransactions();

            return Ok(_mapper.Map<IEnumerable<TransactionReadDto>>(transacionItem));
        }


        //GET api/commands/{id}
        //[Authorize]       //Apply this attribute to lockdown this ActionResult (or others)
        [HttpGet("{id}", Name = "GetTransactionId")]
        public ActionResult<TransactionReadDto> GetTransactionById(int id)
        {
            var transacionItem = _repository.GetTransactionById(id);
            if (transacionItem == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<TransactionReadDto>(transacionItem));
        }

        //POST api/commands/
        [HttpPost]
        public ActionResult<TransactionReadDto> CreateTransaction(TransactionCreateDto transactionCreateDto)
        {
            var transactionModel = _mapper.Map<Transaction>(transactionCreateDto);
            _repository.CreateTransaction(transactionModel);
            _repository.SaveChanges();

            var transactionReadDto = _mapper.Map<TransactionReadDto>(transactionCreateDto);

            return CreatedAtRoute(nameof(GetTransactionById), new { Id = transactionReadDto.Id }, transactionReadDto);
        }



    }
}

using AutoMapper;
using GcoinNode.Data;
using GcoinNode.Dtos;
using GcoinNode.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace GcoinNode.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : Controller
    {

        private readonly ITransactionRepo _repository;
        private readonly IMapper _mapper;

        public HomeController(ITransactionRepo repository, IMapper mapper)
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
        [HttpGet("{id}", Name = "GetTransactionById")]
        public ActionResult<TransactionReadDto> GetTransactionById(int id)
        {
            var transacionItem = _repository.GetTransactionById(id);
            if (transacionItem == null)
            {
                return NotFound();
            }

            var t_dto = _mapper.Map<TransactionReadDto>(transacionItem);

            return Ok(t_dto);
        }

        // POST: api/TodoItems
        [HttpPost]
        public ActionResult<TransactionReadDto> PostTodoItem(TransactionCreateDto transactionCreateDto)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var transactionModel = _mapper.Map<Transaction>(transactionCreateDto);
            _repository.CreateTransaction(transactionModel);
            _repository.SaveChanges();

            var transactionReadDto = _mapper.Map<TransactionReadDto>(transactionModel);

            return CreatedAtRoute(nameof(GetTransactionById), new { Id = transactionReadDto.Id }, transactionReadDto);

        }
    }
}

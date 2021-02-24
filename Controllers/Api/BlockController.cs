using GcoinNode.Dtos;
using AutoMapper;
using GcoinNode.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace GcoinNode.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlockController : Controller
    {

        private readonly IBlockRepo _blockRepository;
        private readonly ITransactionRepo _transactionRepository;
        private readonly IMapper _mapper;

        public BlockController(IBlockRepo BlockRepository, ITransactionRepo transactionRepository,  IMapper mapper)
        {
            _blockRepository = BlockRepository;
            _transactionRepository = transactionRepository;
            _mapper = mapper;
        }

        // GET: BlockController
        [HttpPost]
        public IActionResult AddBlock(int transactionId)
        {
            var transaction = _transactionRepository.GetTransactionById(transactionId);

            List<TransactionReadDto> transactionList = new List<TransactionReadDto>();
            _blockRepository.AddBlock(transactionList);

            return Ok("block added");
        }


       /*
        * Blockchain: block cannot be deleted once added to the chain
        * 
        * public ActionResult Delete(int id)
        {
            return View();
        }*/

/*        // POST: BlockController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }*/
    }
}

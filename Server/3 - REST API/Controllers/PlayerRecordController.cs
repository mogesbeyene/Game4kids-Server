
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Games4Kids
{
    [Route("api/player")]
    [ApiController]
    [EnableCors("Application")]

    public class PlayerRecordController : ControllerBase
    {
        private readonly PlayerRecordLogic playerRecordLogic;


        public PlayerRecordController(PlayerRecordLogic logic)
        {
            playerRecordLogic = logic;
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetOnePlayerRecord(int id)
        {
            try
            {
                PlayerRecordViewModel playerRecord = playerRecordLogic.GetPlayerRecord(id);
                if (playerRecord == null)
                    return NotFound($"id {id} not found");

                return Ok(playerRecord);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ErrorHelper.GetExceptionMessage(ex));
            }
        }

        [HttpPost]
        [Route("add")]
        public IActionResult AddPlayerRecord([FromBody] PlayerRecordViewModel playerRecordViewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ErrorHelper.ExtractErrors(ModelState));

                PlayerRecordViewModel addedPlayerRecord = playerRecordLogic.AddPlayerRecord(playerRecordViewModel);
                return Created("api/player" + addedPlayerRecord.UserID, addedPlayerRecord);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ErrorHelper.GetExceptionMessage(ex));
            }
        }

    }
}

using Microsoft.AspNetCore.Mvc;
using Paramore.Brighter;
using Quiz.Application.Ports.Commands;
using System.Collections.Generic;

namespace Quiz.API.Controllers
{
    [Route("api/[controller]")]
    public class QuestionsController: Controller
    {
        private IAmACommandProcessor _commandProcessor;

        public QuestionsController(IAmACommandProcessor commandProcessor)
        {

        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        
        [HttpGet("{id}", Name ="GetQuestion")]
        public string Get(int id)
        {
            return "value";
        }

     
        [HttpPost]
        public IActionResult Post([FromBody]AddQuestionCommand command)
        {                      
            _commandProcessor.Send(command);

            return this.CreatedAtRoute("GetQuestion", new { id = command.Id }, null);
        }

       
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

      
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

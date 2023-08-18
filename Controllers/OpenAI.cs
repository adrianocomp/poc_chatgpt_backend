﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpenAI_API.Completions;
using OpenAI_API;

namespace OpenAIApp.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OpenAI : ControllerBase
    {
        [HttpGet]
       public async Task<IActionResult> GetData(string input)
        {
            string apiKey = "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";
            //"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";
            string response = "";
            OpenAIAPI openai = new OpenAIAPI(apiKey);
            CompletionRequest completion = new CompletionRequest();
            completion.Prompt = input;
            completion.Model = "text-davinci-003";
            completion.MaxTokens = 4000;
            var output = await openai.Completions.CreateCompletionAsync(completion);
            if (output != null)
            {
                foreach (var item in output.Completions)
                {
                    response = item.Text;
                }
                return Ok(response);
            }
            else
            {
                return BadRequest("Not found");
            }
        }
    }
}
using System;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Conversion;
using GraphQL.Types;
using Microsoft.AspNetCore.Mvc;
using GraphQlMaster.Api.Graphql;

namespace GraphQlMaster.Api.Controllers
{
    [Route("api/[controller]")]
    //[Route("graphql")]
    [ApiController]
    public class MarketingController : ControllerBase
    {
        private readonly IDocumentExecuter _documentExecuter;
        private readonly ISchema _schema;
        public MarketingController(IDocumentExecuter documentExecuter, ISchema schema)
        {
            _documentExecuter = documentExecuter;
            _schema = schema;
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]GraphqlQueryParameter query)
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }

            var executionOptions = new ExecutionOptions
            {
                Schema = _schema,
                Query = query.Query,
                Inputs = query.Variables?.ToInputs(), //TODO: Jsondaki variable kısmının tanımlanması için
                FieldNameConverter = new PascalCaseFieldNameConverter() //TODO: Graphql sorgularının pascal case olarak yazılması için gerekli.
            };

            try
            {
                var result = await _documentExecuter.ExecuteAsync(executionOptions).ConfigureAwait(false);

                if (result.Errors?.Count > 0)
                {
                    return BadRequest(result);
                }

                return Ok(result.Data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

    }
}
using DotNetTrainingProject.Entities;

namespace DotNetTrainingProject.Requests
{
    public class TestTransactionRequest
    {
        public ProductDTO Product { get; set; }
        public ProductGroupDTO ProductGroup { get; set; }
    }
}

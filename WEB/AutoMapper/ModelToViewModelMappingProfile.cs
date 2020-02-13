using AutoMapper;
using WEB.Models;
using WEB.ViewModels;

namespace WEB.AutoMapper
{
    public class ModelToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "ModelToViewModelMapping"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<ProdutoViewModel, Produto>();
            Mapper.CreateMap<ProdutoCompostoViewModel, ProdutoComposto>();
            Mapper.CreateMap<RequisicaoViewModel, Requisicao>();
        }
    }
}
using AutoMapper;
using WEB.Models;
using WEB.ViewModels;

namespace WEB.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "ViewModelToDomainMapping"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<Produto, ProdutoViewModel>();
            Mapper.CreateMap<ProdutoComposto, ProdutoCompostoViewModel>();
            Mapper.CreateMap<Requisicao, RequisicaoViewModel>();
        }
    }
}
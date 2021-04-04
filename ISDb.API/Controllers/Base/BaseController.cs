using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISDb.API.Controllers.Base
{
    public class BaseController<TModel, TViewModel> : ControllerBase
    where TModel : class
    where TViewModel : class
    {
        protected readonly IMapper Mapper;

        public BaseController(IMapper mapper)
        {
            this.Mapper = mapper;
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        public TModel ToModel(TViewModel viewModel)
    => this.Mapper.Map<TViewModel, TModel>(viewModel);

        [ApiExplorerSettings(IgnoreApi = true)]
        public List<TModel> ToModelList(List<TViewModel> viewModelList)
            => this.Mapper.Map<List<TViewModel>, List<TModel>>(viewModelList);

        [ApiExplorerSettings(IgnoreApi = true)]
        public TViewModel ToViewModel(TModel model)
            => this.Mapper.Map<TModel, TViewModel>(model);

        [ApiExplorerSettings(IgnoreApi = true)]
        public List<TViewModel> ToViewModelList(List<TModel> modelList)
            => this.Mapper.Map<List<TModel>, List<TViewModel>>(modelList);
    }
}

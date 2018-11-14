namespace Sitecore.Support.Commerce.XA.Feature.Cart.Repositories
{
  using Sitecore.Commerce.XA.Feature.Cart.Models;
  using Sitecore.Commerce.XA.Foundation.Common.Context;
  using Sitecore.Commerce.XA.Foundation.Common.Models;
  using Sitecore.Commerce.XA.Foundation.Connect;
  using Sitecore.Commerce.XA.Foundation.Connect.Managers;

  public class MinicartRepository : Sitecore.Commerce.XA.Feature.Cart.Repositories.MinicartRepository
  {
    public MinicartRepository(IModelProvider modelProvider, ICartManager cartManager, ISiteContext siteContext) : base(modelProvider, cartManager, siteContext)
    {
    }

    public override MinicartRenderingModel GetMinicartModel(IStorefrontContext storefrontContext, IVisitorContext visitorContext)
    {
      Sitecore.Support.Commerce.XA.Feature.Cart.Models.MinicartRenderingModel model = base.ModelProvider.GetModel<Sitecore.Support.Commerce.XA.Feature.Cart.Models.MinicartRenderingModel>();
      base.Init(model);
      model.Initialize();
      return model;
    }
  }
}
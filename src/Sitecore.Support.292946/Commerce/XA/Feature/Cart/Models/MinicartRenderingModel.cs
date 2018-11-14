namespace Sitecore.Support.Commerce.XA.Feature.Cart.Models
{
  using Sitecore.Commerce.XA.Foundation.Common.Context;
  using Sitecore.Mvc.Extensions;
  using Sitecore.Mvc.Presentation;

  public class MinicartRenderingModel : Sitecore.Commerce.XA.Feature.Cart.Models.MinicartRenderingModel
  {
    public MinicartRenderingModel([NotNull] IStorefrontContext storefrontContext) : base(storefrontContext)
    {
      this.StorefrontContext = storefrontContext;
    }

    public new string CheckoutLink { get; set; }

    public new bool HideCheckoutButton { get; set; }

    public new IStorefrontContext StorefrontContext { get; set; }

    public new string TopLink { get; set; }

    public new string ViewCartLink { get; set; }

    public new void Initialize()
    {
      var currentRendering = RenderingContext.CurrentOrNull.ValueOrDefault(context => context.Rendering);
      if (currentRendering != null)
      {
        var checkoutPath = currentRendering.Parameters["Checkout Link"] ?? string.Empty;
        #region Changed code
        var viewCartPath = currentRendering.Parameters["View Cart Link"] ?? string.Empty; // removed this.TopLink initialization
        #endregion
        var checkoutPageItem = Context.Database.GetItem(checkoutPath);
        var viewCartPageItem = Context.Database.GetItem(viewCartPath);
        this.CheckoutLink = this.StorefrontContext.StorefrontUri(checkoutPageItem).Path;
        #region Changed code
        this.ViewCartLink = this.TopLink = this.StorefrontContext.StorefrontUri(viewCartPageItem).Path; // added this.TopLink initialization
        #endregion
        this.HideCheckoutButton = MainUtil.GetBool(currentRendering.Parameters["Hide Checkout Button"], false);
      }
    }
  }
}
#pragma checksum "/Users/amulyakakumanu/Desktop/revature/projects/p1/aspnet/PizzaBox.Client/Views/Shared/OrderHistory.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "29088337f99a00c3175c1e563ed7fc6582d32c4a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_OrderHistory), @"mvc.1.0.view", @"/Views/Shared/OrderHistory.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "/Users/amulyakakumanu/Desktop/revature/projects/p1/aspnet/PizzaBox.Client/Views/_ViewImports.cshtml"
using PizzaBox.Client;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/Users/amulyakakumanu/Desktop/revature/projects/p1/aspnet/PizzaBox.Client/Views/_ViewImports.cshtml"
using PizzaBox.Client.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"29088337f99a00c3175c1e563ed7fc6582d32c4a", @"/Views/Shared/OrderHistory.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0869890531cd973fc94231944f02086ee7830497", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_OrderHistory : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "/Users/amulyakakumanu/Desktop/revature/projects/p1/aspnet/PizzaBox.Client/Views/Shared/OrderHistory.cshtml"
 foreach (var order in @Model.Orders)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"row\">\n        <h3>Order : has ");
#nullable restore
#line 4 "/Users/amulyakakumanu/Desktop/revature/projects/p1/aspnet/PizzaBox.Client/Views/Shared/OrderHistory.cshtml"
                   Write(order.Pizzas.Count);

#line default
#line hidden
#nullable disable
            WriteLiteral(" Pizzas and cost: $");
#nullable restore
#line 4 "/Users/amulyakakumanu/Desktop/revature/projects/p1/aspnet/PizzaBox.Client/Views/Shared/OrderHistory.cshtml"
                                                         Write(order.TotalPrice);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\n    </div>\n");
#nullable restore
#line 6 "/Users/amulyakakumanu/Desktop/revature/projects/p1/aspnet/PizzaBox.Client/Views/Shared/OrderHistory.cshtml"
}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591

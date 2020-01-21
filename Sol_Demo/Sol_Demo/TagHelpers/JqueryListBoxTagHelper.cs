using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.Runtime.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Newtonsoft.Json;

namespace Sol_Demo.TagHelpers
{
    // You may need to install the Microsoft.AspNetCore.Razor.Runtime package into your project
    [HtmlTargetElement("jQuery-Listbox")]
    public class JqueryListBoxTagHelper : TagHelper
    {
        private readonly IHtmlHelper htmlHelper = null;

        private const string ItemSourceAttributeName = "item-source";
        private const string OnSelectedPositionAttributeName = "on-selected-index";
        private const string ButtonIdAttributeName = "on-getitem-button-id";
       

        public JqueryListBoxTagHelper(IHtmlHelper htmlHelper)
        {
            this.htmlHelper = htmlHelper;
        }


        [HtmlAttributeName(ItemSourceAttributeName)]
        public List<String> ItemSource { get; set; }

        [HtmlAttributeName(OnSelectedPositionAttributeName)]
        public int OnSelectedIndex { get; set; }

        [HtmlAttributeName(ButtonIdAttributeName)]
        public String OnGetItemButtonId { get; set; }


        [HtmlAttributeNotBound]
        [ViewContext]
        public ViewContext ViewContext { get; set; }

        public async override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            //Contextualize the html helper
            (htmlHelper as IViewContextAware).Contextualize(ViewContext);

            var jqueryListBoxModel = new JqueryListBoxModel()
            {
                ItemSource = JsonConvert.SerializeObject(ItemSource),
                OnSelectedIndex = OnSelectedIndex,
                OnGetItemButtonId=OnGetItemButtonId
               
            };

            var content = await htmlHelper?.PartialAsync("~/Views/Shared/_JqueryListBoxPartialView.cshtml", jqueryListBoxModel);

            output.Content.SetHtmlContent(content);

            //return base.ProcessAsync(context, output);
        }
    }
}

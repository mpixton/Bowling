using Bowling.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.Runtime.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bowling.Infrastructure.TagHelpers
{
    /// <summary>
    /// Tag Helper to provide links to pages. 
    /// </summary>
    [HtmlTargetElement("div", Attributes = "paginator")]
    public class PaginatorTagHelper : TagHelper
    {
        private IUrlHelperFactory _urlHelperFactory;

        public PaginatorTagHelper(IUrlHelperFactory urlhf)
        {
            _urlHelperFactory = urlhf;
        }

        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext ViewContext { get; set; }

        /// <summary>
        /// Paginator that contains all the info for actual pagination.
        /// </summary>
        public Paginator<Bowler> Paginator { get; set; }

        /// <summary>
        /// Action the link will execute on in the current controller.
        /// </summary>
        public string PageAction { get; set; }
       
        /// <summary>
        /// Dictionary of values to be used on the PageAction.
        /// </summary>
        [HtmlAttributeName(DictionaryAttributePrefix = "page-url-")]
        public Dictionary<String, object> PageUrlValues { get; set; } = new Dictionary<string, object>();

        /// <summary>
        /// Determines CSS classes will be applied to the output.
        /// </summary>
        public bool PageClassesEnabled { get; set; } = false;

        /// <summary>
        /// CSS classes to be added to all new tags.
        /// </summary>
        public string PageClass { get; set; }

        /// <summary>
        /// CSS class to be added to the unselected links.
        /// </summary>
        public string PageClassNormal { get; set; }

        /// <summary>
        /// CSS class to be added to the selected link.
        /// </summary>
        public string PageClassSelected { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            IUrlHelper urlHelper = _urlHelperFactory.GetUrlHelper(ViewContext);

            var result = new TagBuilder("div");

            for (var i = 1; i <= Paginator.TotalPages; i++)
            {
                var tag = new TagBuilder("a");
                PageUrlValues["pageNum"] = i;
                tag.Attributes["href"] = urlHelper.Action(PageAction, PageUrlValues);

                if(PageClassesEnabled)
                {
                    tag.AddCssClass(PageClass);
                    tag.AddCssClass(i == Paginator.CurrentPage ? PageClassSelected : PageClassNormal);
                }

                tag.InnerHtml.Append(i.ToString());

                result.InnerHtml.AppendHtml(tag);
            }

            output.Content.AppendHtml(result.InnerHtml);
        }
    }
}

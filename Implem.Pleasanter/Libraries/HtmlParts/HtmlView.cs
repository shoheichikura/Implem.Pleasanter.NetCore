﻿using Implem.Libraries.Utilities;
using Implem.Pleasanter.Libraries.Html;
using Implem.Pleasanter.Libraries.Requests;
using Implem.Pleasanter.Libraries.Responses;
using Implem.Pleasanter.Libraries.Settings;
using System.Linq;
namespace Implem.Pleasanter.Libraries.HtmlParts
{
    public static class HtmlView
    {
        public static HtmlBuilder ViewSelector(
            this HtmlBuilder hb,
            Context context,
            SiteSettings ss,
            View view)
        {
            return hb.FieldDropDown(
                context: context,
                fieldId: "_ViewSelectorField",
                controlId: "ViewSelector",
                controlCss: " auto-postback",
                labelText: Displays.DataView(context: context),
                optionCollection: ss.Views?.ToDictionary(o =>
                    o.Id.ToString(), o => o.Name),
                selectedValue: ss.Views?.FirstOrDefault(o =>
                    o.Id == view.Id)?.Id.ToString(),
                addSelectedValue: false,
                insertBlank: ss.AllowViewReset != false,
                method: "post",
                _using: ss.Views?.Any() == true);
        }
    }
}
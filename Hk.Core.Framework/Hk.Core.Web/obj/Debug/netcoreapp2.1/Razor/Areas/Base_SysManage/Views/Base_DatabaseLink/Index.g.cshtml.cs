#pragma checksum "F:\SVN\20SVN\Hk.Core.Framework\Hk.Core.Web\Areas\Base_SysManage\Views\Base_DatabaseLink\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ab8858b010a24557c29a8d07549c285bf412596d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Base_SysManage_Views_Base_DatabaseLink_Index), @"mvc.1.0.view", @"/Areas/Base_SysManage/Views/Base_DatabaseLink/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/Base_SysManage/Views/Base_DatabaseLink/Index.cshtml", typeof(AspNetCore.Areas_Base_SysManage_Views_Base_DatabaseLink_Index))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ab8858b010a24557c29a8d07549c285bf412596d", @"/Areas/Base_SysManage/Views/Base_DatabaseLink/Index.cshtml")]
    public class Areas_Base_SysManage_Views_Base_DatabaseLink_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "F:\SVN\20SVN\Hk.Core.Framework\Hk.Core.Web\Areas\Base_SysManage\Views\Base_DatabaseLink\Index.cshtml"
  
    Layout = "~/Views/Shared/_Layout_List.cshtml";

#line default
#line hidden
            BeginContext(59, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            DefineSection("toolbar", async() => {
                BeginContext(78, 262, true);
                WriteLiteral(@"
    <a id=""add"" class=""easyui-linkbutton"" data-options=""iconCls:'icon-add'"">添加</a>
    <a id=""edit"" class=""easyui-linkbutton"" data-options=""iconCls:'icon-edit'"">修改</a>
    <a id=""delete"" class=""easyui-linkbutton"" data-options=""iconCls:'icon-remove'"">删除</a>
");
                EndContext();
            }
            );
            BeginContext(343, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            DefineSection("search", async() => {
                BeginContext(361, 820, true);
                WriteLiteral(@"
    <div class=""search_wrapper"">
        <div class=""search_item"">
            <label class=""search_label"">查询类别</label>
            <select name=""condition"" class=""easyui-combobox"" data-options=""width:100"">
                <option value="""">请选择</option>

                <option value=""LinkName"">连接名</option>
                <option value=""ConnectionStr"">连接字符串</option>
                <option value=""DbType"">数据库类型</option>
                <option value=""SortNum"">排序编号</option>
            </select>
            <input name=""keyword"" class=""easyui-textbox"" style=""width:150px"" />
        </div>
        <div class=""search_submit"">
            <a href=""javascript:;"" class=""easyui-linkbutton"" data-options=""iconCls:'icon-search'"" onclick=""searchGrid(this,'#dataTable')"">查询</a>
        </div>
    </div>
");
                EndContext();
            }
            );
            BeginContext(1184, 63, true);
            WriteLiteral("<div id=\"dataTable\">\r\n\r\n</div>\r\n\r\n<script>\r\n    var rootUrl = \'");
            EndContext();
            BeginContext(1248, 17, false);
#line 35 "F:\SVN\20SVN\Hk.Core.Framework\Hk.Core.Web\Areas\Base_SysManage\Views\Base_DatabaseLink\Index.cshtml"
              Write(Url.Content("~/"));

#line default
#line hidden
            EndContext();
            BeginContext(1265, 3006, true);
            WriteLiteral(@"';

    function initTable() {
        $('#dataTable').datagrid({
            url: rootUrl + 'Base_SysManage/Base_DatabaseLink/GetDataList',
            method: 'POST',
            //queryParams: { 'id': id },
            idField: 'Id',
            fit: true,
            fitColumns: true,
            singleSelect: false,
            selectOnCheck: false,
            checkOnSelect: false,
            //rownumbers: true,
            pagination: true,
            pageSize: 30,
            //nowrap: false,
            pageList: [10, 20, 30, 50, 100, 150, 200],
            //showFooter: true,
            columns: [[
                { title: 'ck', field: 'ck', checkbox: true },

                { title: '连接名', field: 'LinkName', width: 300 },
                { title: '连接字符串', field: 'ConnectionStr', width: 1000 },
                { title: '数据库类型', field: 'DbType', width: 200 },
                { title: '排序编号', field: 'SortNum', width: 200 }
            ]],
            onBeforeSelect: func");
            WriteLiteral(@"tion () {
                return false;
            }
        });
    }

    $(function () {
        initTable();

        //添加数据
        $('#add').click(function () {
            dialogOpen({
                id: 'form',
                title: '添加数据',
                width: 500,
                height: 340,
                url: rootUrl + 'Base_SysManage/Base_DatabaseLink/Form',
            });
        });

        //修改数据
        $('#edit').click(function () {
            var selected = $(""#dataTable"").datagrid(""getChecked"");
            if (!selected || !selected.length) {
                dialogError('请选择要修改的记录!');
                return;
            }
            var id = selected[0].Id;

            dialogOpen({
                id: 'form',
                title: '修改数据',
                width: 500,
                height: 340,
                url: rootUrl + 'Base_SysManage/Base_DatabaseLink/Form?id=' + id,
            });
        });

        //删除数据
        $('#delete')");
            WriteLiteral(@".click(function () {
            var checked = $(""#dataTable"").datagrid(""getChecked"");
            if (!checked || !checked.length) {
                dialogError('请选择要删除的记录!');
                return;
            }
            var ids = $.map(checked, function (item) {
                return item['Id'];
            });

            dialogComfirm('确认删除吗？', function () {
                $.postJSON(rootUrl + 'Base_SysManage/Base_DatabaseLink/DeleteData', { ids: JSON.stringify(ids) }, function (resJson) {
                    if (resJson.Success) {
                        $('#dataTable').datagrid('clearSelections').datagrid('clearChecked');
                        $('#dataTable').datagrid('reload');
                        dialogMsg('删除成功!');
                    }
                    else {
                        dialogError(resJson.Msg);
                    }
                });
            });
        });
    });
</script>");
            EndContext();
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

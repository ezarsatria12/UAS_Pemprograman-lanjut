<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="~/page/Shop.aspx.cs" MasterPageFile="~/page/master.master" Inherits="UAS_Pemprogramanlanjut_2203040104.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="hero container max-w-screen-xl flex flex-col justify-between mx-32 px-2">
        <div class="">
            <asp:Button ID="btn_add" runat="server" CssClass="px-4 py-2 rounded-lg bg-white font-primary text-white font-medium w-auto" Text="Add" BackColor="#658864" ForeColor="White" OnClick="Btn_add"/>
        </div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource2" CssClass="w-full" DataKeyNames="ID" AllowPaging="True" AllowSorting="True" OnRowEditing="GridView1_RowEditing" OnRowDeleting="GridView1_RowDeleting">
            <HeaderStyle CssClass="bg-blue-500 text-white font-bold" />
            <RowStyle CssClass="text-gray-500 dark:text-gray-400" />
            <AlternatingRowStyle CssClass="bg-gray-100" />
            <Columns>
                <asp:TemplateField HeaderText="No">
                    <ItemTemplate>
                        <asp:Label ID="LblNo" runat="server" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Image">
                    <ItemTemplate>
                        <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("ITEM_IMAGE") %>' Width="100" Height="100" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="ITEM_NAME" HeaderText="Name" SortExpression="ITEM_NAME" />
                <asp:TemplateField HeaderText="Place">
                    <ItemTemplate>
                        <asp:Label ID="LblPlace" runat="server" Text='<%# Eval("PLACE_NAME") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Category">
                    <ItemTemplate>
                        <asp:Label ID="LblCategory" runat="server" Text='<%# Eval("CATEGORY") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="ITEM_HEIGHT" HeaderText="Height" SortExpression="ITEM_HEIGHT" />
                <asp:BoundField DataField="ITEM_STOCK" HeaderText="Stock" SortExpression="ITEM_STOCK" />
                <asp:BoundField DataField="ITEM_PRICE" HeaderText="Price" SortExpression="ITEM_PRICE" />
                <asp:TemplateField HeaderText="Action">
                    <ItemTemplate>
                        <asp:Button ID="btnEdit" runat="server" Text="Edit" CommandName="Edit" CommandArgument='<%# Eval("ID") %>' CssClass="bg-blue-500 hover:bg-blue-700 text-white font-bold py-2 px-4 rounded" />
                        <asp:Button ID="BtnDelete" runat="server" Text="Delete" CommandName="Delete" CommandArgument='<%# Eval("ID") %>' CssClass="bg-red-500 hover:bg-red-700 text-white font-bold py-2 px-4 rounded" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>


        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:tabelitem %>" ProviderName="<%$ ConnectionStrings:tabelitem.ProviderName %>" SelectCommand="SELECT ITEMS.ID, PLACE.PLACE_NAME, CATEGORY.CATEGORY, ITEMS.ITEM_NAME, ITEMS.ITEM_IMAGE, ITEMS.ITEM_AGE, ITEMS.ITEM_HEIGHT, ITEMS.ITEM_STOCK, ITEMS.ITEM_PRICE, ITEMS.CREATE_AT FROM ITEMS, PLACE, CATEGORY WHERE ITEMS.PLACE_ID = PLACE.ID AND ITEMS.CATEGORY_ID = CATEGORY.ID" DeleteCommand="DELETE FROM ITEMS WHERE ID = :ID">
            
        </asp:SqlDataSource>
        <asp:Label ID="lblUserId" Text="" runat="server" />
        <asp:Label ID="lblUserFullName" Text="" runat="server" />
        <asp:Label ID="lblUserPassword" Text="" runat="server" />
    </div>
</asp:Content>

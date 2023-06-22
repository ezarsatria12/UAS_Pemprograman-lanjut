<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Add.aspx.cs" MasterPageFile="~/page/add_edit/add_edit.master" Inherits="UAS_Pemprogramanlanjut_2203040104.page.add_edit.Add" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="bg-lightgrey container w-1/2 px-28 flex flex-col justify-center" style="background-color: #DDDDDD;">
        <form id="Form1" runat="server">
            <div class="h-screen flex flex-row">
                <div class="flex flex-col w-full justify-center gap-8">
                    <div class="flex flex-col gap-2">
                        <h2 class="font-primary font-medium text-3xl">Add Item!</h2>
                    </div>
                    <div class="flex flex-col">
                        <div class="flex flex-row justify-between">
                            <div class="flex flex-col gap-2">
                                <div class="flex flex-col gap-1">
                                    <label class="font-secondary text-sm">Plant name</label>
                                    <asp:TextBox runat="server" placeholder="Enter plant name" CssClass="block px-4 py-2 rounded-lg bg-white font-primary font-medium" Style="background-color: #DDDDDD; border: 2px solid #999999; border-radius: 8px;" ID="TxtPlantname"></asp:TextBox>
                                </div>
                                <div class="flex flex-col col-1">
                                    <label class="font-secondary text-sm">Height</label>
                                    <asp:TextBox runat="server" placeholder="Enter your password" TextMode="Number" CssClass="block px-4 py-2 rounded-lg bg-white font-primary font-medium" Style="background-color: #DDDDDD; border: 2px solid #999999; border-radius: 8px;" ID="TxtHeight"></asp:TextBox>
                                </div>
                                <div class="flex flex-col gap-1">
                                    <label class="font-secondary text-sm">Age (moonth)</label>
                                    <asp:TextBox runat="server" placeholder="Enter your name" TextMode="Number" CssClass="block px-4 py-2 rounded-lg bg-white font-primary font-medium" Style="background-color: #DDDDDD; border: 2px solid #999999; border-radius: 8px;" ID="TxtAge"></asp:TextBox>
                                </div>
                                <div class="flex flex-col col-1">
                                    <label class="font-secondary text-sm">Place</label>
                                    <asp:DropDownList ID="DdPlace" runat="server" CssClass="block px-4 py-2 rounded-lg bg-white font-primary font-medium" Style="background-color: #DDDDDD; border: 2px solid #999999; border-radius: 8px;" AppendDataBoundItems="true">
                                        <asp:ListItem Text="-Chose Place-" Value=""></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="flex flex-col gap-2">
                                <div class="flex flex-col gap-1">
                                    <label class="font-secondary text-sm">Price</label>
                                    <asp:TextBox runat="server" placeholder="Enter your name" TextMode="Number" CssClass="block px-4 py-2 rounded-lg bg-white font-primary font-medium" Style="background-color: #DDDDDD; border: 2px solid #999999; border-radius: 8px;" ID="TxtPrice"></asp:TextBox>
                                </div>
                                <div class="flex flex-col col-1">
                                    <label class="font-secondary text-sm">Stock</label>
                                    <asp:TextBox runat="server" placeholder="Enter your password" TextMode="Number" CssClass="block px-4 py-2 rounded-lg bg-white font-primary font-medium" Style="background-color: #DDDDDD; border: 2px solid #999999; border-radius: 8px;" ID="TxtStock"></asp:TextBox>
                                </div>
                                <div class="flex flex-col gap-1">
                                    <label class="font-secondary text-sm">Category</label>
                                    <asp:DropDownList ID="DdCategory" runat="server" CssClass="block px-4 py-2 rounded-lg bg-white font-primary font-medium" Style="background-color: #DDDDDD; border: 2px solid #999999; border-radius: 8px;" AppendDataBoundItems="true">
                                        <asp:ListItem Text="-Chose Category-" Value=""></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="flex flex-col col-1">
                            <label class="font-secondary text-sm">Image</label>
                            <asp:FileUpload runat="server" ID="fileGambar" CssClass="block px-4 py-2 rounded-lg bg-white font-primary font-medium" Style="background-color: #DDDDDD; border: 2px solid #999999; border-radius: 8px;"></asp:FileUpload>
                        </div>
                    </div>
                    <asp:Button runat="server" CssClass="block px-4 py-2 rounded-lg bg-white font-primary text-white font-medium hover:shadow-lg" Text="Create" Style="background-color: #658864;" OnClick="Btn_create" />
                </div>
            </div>
        </form>
    </div>
</asp:Content>

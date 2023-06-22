﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" MasterPageFile="~/page/auth/auth.master" Inherits="UAS_Pemprogramanlanjut_2203040104.page.auth.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="bg-lightgrey container w-1/2 px-56 flex flex-col justify-center" style="background-color: #DDDDDD;">
        <form id="Form1" runat="server">
            <div class="h-screen flex flex-row">
                <div class="flex flex-col w-full justify-center gap-8">
                    <div class="flex flex-col gap-2">
                        <h2 class="font-primary font-medium text-3xl">Welcome!</h2>
                        <p class="font-secondary text-base" style="color: #666666;">Please enter your detail</p>
                    </div>
                    <div class="flex flex-col gap-2">
                        <div class="flex flex-col gap-1">
                            <label class="font-secondary text-sm">User name</label>
                            <asp:TextBox runat="server" placeholder="Enter your name" CssClass="block px-4 py-2 rounded-lg bg-white font-primary font-medium" Style="background-color: #DDDDDD; border: 2px solid #999999; border-radius: 8px;" ID="txtUsername"></asp:TextBox>
                        </div>
                        <div class="flex flex-col col-1">
                            <label class="font-secondary text-sm">Password</label>
                            <asp:TextBox runat="server" placeholder="Enter your password" TextMode="Password" CssClass="block px-4 py-2 rounded-lg bg-white font-primary font-medium" Style="background-color: #DDDDDD; border: 2px solid #999999; border-radius: 8px;" ID="txtPassword"></asp:TextBox>
                        </div>
                    </div>
                    <asp:Button runat="server" CssClass="block px-4 py-2 rounded-lg bg-white font-primary text-white font-medium hover:shadow-lg" Text="Login" Style="background-color: #658864;" OnClick="btnLogin_Click" />
                    <p class="flex justify-center">Don’t have an acount? <span><a class="text-sagegreen" href="Signup.aspx">Sign up</a></span></p>
                </div>
            </div>
        </form>
    </div>
</asp:Content>

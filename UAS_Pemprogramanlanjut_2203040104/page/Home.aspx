<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="~/page/Home.aspx.cs" MasterPageFile="~/page/master.master" Inherits="UAS_Pemprogramanlanjut_2203040104.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="hero container max-w-screen-xl flex flex-row justify-between mx-32 px-2">
        <div class="text flex flex-col justify-center w-2/5 gap-4">
            <h1 class="font-primary font-medium text-6xl">Beautiful <span class="text-sagegreen">Green</span> Spaces Await You </h1>
            <p class="font-secondary leading-8 text-base text-opacity-25" style="color: #666666; letter-spacing: 0.01em; line-height: 160%;">Provide your house & office space with the right plant and lets our car team keep the flourishing</p>
            <asp:Button runat="server" CssClass="px-4 py-2 rounded-lg bg-white font-primary text-white font-medium w-auto" Text="Shop Now" BackColor="#658864" ForeColor="White" />
        </div>
        <div class="imagehero justify-items-end">
            <asp:Image ImageUrl="../Image/heroimage.png" CssClass="w-full justify-items-end" runat="server" />
        </div>
    </div>
    <div class="container h-screen justify-between bg-lightgray">
        <div class="justify-between h-screen flex flex-row mx-32 px-2 gap-28">
            <div class="flex flex-col w-5/6 justify-center">
                <asp:Image ImageUrl="../Image/woman.png" CssClass="justify-items-end" runat="server" />
            </div>
            <div class="flex flex-col w-auto justify-center gap-4">
                <h2 class="font-primary font-medium text-5xl" style="line-height: 60px; letter-spacing: 0.01em;">Make Your Room <span class="text-sagegreen">Aesthetic</span></h2>
                <p class="font-secondary leading-8 text-base text-opacity-25" style="color: #666666; letter-spacing: 0.01em; line-height: 160%;">Decorate your room with our selected plants which of course are suitable for indoor.</p>
            </div>
        </div>
    </div>
    <div class="container h-screen bg-white">
        <div class="flex flex-col mx-32 px-2 gap-4 justify-center">
            <div class="flex flex-col gap-12">
                <h1 class="font-primary font-medium text-5xl text-center">Our Advantage</h1>
                <div class="justify-between h-auto flex flex-row">
                    <div class="relative overflow-hidden bg-gray-200 rounded-lg shadow-lg">
                        <asp:Image CssClass="object-cover object-center  w-auto h-auto transition-all duration-300 transform hover:scale-105" ImageUrl="../Image/card1.jpg" alt="Background Image" runat="server" />

                        <div class="absolute inset-0 bg-gradient-to-t from-gray-900 to-transparent opacity-0 hover:opacity-100 transition-opacity duration-300">
                            <div class="absolute bottom-0 p-6">
                                <h2 class="text-2xl font-bold text-white">Judul Card</h2>
                                <p class="mt-2 text-gray-300">Penjelasan singkat tentang card ini.</p>
                            </div>
                        </div>
                    </div>
                    <div class="relative overflow-hidden bg-gray-200 rounded-lg shadow-lg">
                        <asp:Image CssClass="object-cover object-center w-auto h-auto transition-all duration-300 transform hover:scale-105" ImageUrl="../Image/card2.jpg" alt="Background Image" runat="server" />

                        <div class="absolute inset-0 bg-gradient-to-t from-gray-900 to-transparent opacity-0 hover:opacity-100 transition-opacity duration-300">
                            <div class="absolute bottom-0 p-6">
                                <h2 class="text-2xl font-bold text-white">Judul Card</h2>
                                <p class="mt-2 text-gray-300">Penjelasan singkat tentang card ini.</p>
                            </div>
                        </div>
                    </div>
                    <div class="relative overflow-hidden bg-gray-200 rounded-lg shadow-lg">
                        <asp:Image CssClass="object-cover object-center w-auto h-auto transition-all duration-300 transform hover:scale-105" ImageUrl="../Image/card3.jpg" alt="Background Image" runat="server" />

                        <div class="absolute inset-0 bg-gradient-to-t from-gray-900 to-transparent opacity-0 hover:opacity-100 transition-opacity duration-300">
                            <div class="absolute bottom-0 p-6">
                                <h2 class="text-2xl font-bold text-white">Judul Card</h2>
                                <p class="mt-2 text-gray-300">Penjelasan singkat tentang card ini.</p>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="">
                <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24" width="16" height="16">
                    <path d="M12 22C6.47715 22 2 17.5228 2 12C2 6.47715 6.47715 2 12 2C17.5228 2 22 6.47715 22 12C22 17.5228 17.5228 22 12 22ZM12 20C16.4183 20 20 16.4183 20 12C20 7.58172 16.4183 4 12 4C7.58172 4 4 7.58172 4 12C4 16.4183 7.58172 20 12 20ZM11 15H13V17H11V15ZM11 7H13V13H11V7Z" fill="rgba(101,136,100,1)"></path></svg>
            </div>
        </div>
    </div>
</asp:Content>

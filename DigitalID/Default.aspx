<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="DigitalID._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div style="height: 100px;">&nbsp;</div>


    <div class="container">

        <div class="panel panel-default" >
            <div class="panel-heading">
                <h4 class="panel-title"
                    data-toggle="collapse"
                    data-target="#searchPanel" style="cursor: pointer;">ძებნა
                </h4>
            </div>
            <div id="searchPanel" class="panel-collapse collapse">
                <div class="panel-body">
                    <div class="row">
                        <div class="form-horizontal">
                            <div class="form-group">
                                <div class="col-lg-3">
                                    <label class="sr-only" for="">სახელი გვარი</label>
                                    <asp:TextBox runat="server" ID="nameInput" CssClass="form-control" placeholder="სახელი გვარი"></asp:TextBox>
                                </div>
                                <div class="col-lg-3">
                                    <label class="sr-only" for="">პირადი ნომერი</label>
                                    <asp:TextBox runat="server" ID="pnInput" CssClass="form-control" placeholder="პირადი ნომერი"></asp:TextBox>
                                </div>
                                <div class="col-lg-3">
                                    <label class="sr-only" for="">დაბადების ადგილი</label>
                                    <asp:DropDownList ID="birthPlaceInput" runat="server" CssClass="form-control" DataTextField="PlaceName"
                                        DataValueField="ID">
                                    </asp:DropDownList>
                                </div>


                            </div>
                            <div class="form-group">
                                <div class="col-lg-3">
                                    <label class="sr-only" for="">დაბადების თარიღი -დან</label>
                                    <asp:TextBox runat="server" ID="bDateFromInput" CssClass="form-control datepicker" placeholder="დაბადების თარიღი -დან"></asp:TextBox>
                                </div>

                                <div class="col-lg-3">
                                    <label class="sr-only" for="">დაბადების თარიღი -მდე</label>
                                    <asp:TextBox runat="server" ID="bDateToInput" CssClass="form-control datepicker" placeholder="დაბადების თარიღი -მდე"></asp:TextBox>
                                </div>
                            </div>

                            <div class="form-group">
                                <div class="col-lg-3">
                                    <label class="sr-only" for="">მოქმედების ვადა -დან</label>
                                    <asp:TextBox runat="server" ID="validDateFromInput" CssClass="form-control datepicker" placeholder="მოქმედების ვადა -დან"></asp:TextBox>
                                </div>
                                <div class="col-lg-3">
                                    <label class="sr-only" for="">მოქმედების ვადა -მდე</label>
                                    <asp:TextBox runat="server" ID="validDateToInput" CssClass="form-control datepicker" placeholder="მოქმედების ვადა -მდე"></asp:TextBox>
                                </div>

                            </div>
                            <div class="form-group">
                                <div class="col-lg-12">
                                   
                                    <asp:HiddenField ID="collapseField" runat="server" />  
                                    <asp:Button runat="server" Text="გასუფთავება" CausesValidation="false" OnClick="ClearSearch" CssClass="btn btn-default pull-right" />
                                    <asp:Button runat="server" Text="ძებნა" CausesValidation="false" OnClick="FilterData" CssClass="btn btn-default pull-right" />
                                </div>
                            </div>

                        </div>

                    </div>
                </div>
            </div>
        </div>

    </div>


    <div class="divider">
        &nbsp;
    </div>

    <div class="row">
        <a href="/CreateEdit" class="btn btn-success">დამატება</a>
    </div>

    <div class="divider">&nbsp;</div>
    <%-- <div class="row">
        <asp:ListView ID="idCardList" runat="server"
            ItemType="DigitalID.Models.IdCard" SelectMethod="GetCards" AllowSorting="true" AllowPaging="true">
            <LayoutTemplate>
                <table class="table table-striped">
                    <thead>
                        <tr runat="server" id="headerRow">
                            <th>სახელი და გვარი

                            </th>
                            <th>პირადი ნომერი
                            </th>
                            <th>სქესი
                            </th>
                            <th>დაბადების თარიღი
                            </th>
                            <th>მოქმედების ვადა
                            </th>
                            <th></th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr runat="server" id="itemPlaceholder" />
                    </tbody>
                </table>
            </LayoutTemplate>
            <EmptyDataTemplate>
                <table>
                    <tr>
                        <td>No data was returned.</td>
                    </tr>
                </table>
            </EmptyDataTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                        <%# Item.FirstName+" "+Item.LastName%>
                    </td>
                    <td>
                        <%# Item.PersonalNr%>
                    </td>
                    <td>
                        <%# Item.Gender.GenderName%>
                    </td>
                    <td>
                        <%# Item.BirthDate.ToString("yyyy-MM-dd")%>
                    </td>
                    <td>
                        <%# Item.ValidityDate.ToString("yyyy-MM-dd")%>
                    </td>
                    <td>
                       
                    </td>

                </tr>
            </ItemTemplate>
        </asp:ListView>
    </div>--%>
    <div class="row">
        <asp:GridView ID="cartGrid" DataKeyNames="ID" runat="server" AutoGenerateColumns="false" ItemType="DigitalID.Models.IdCard" DeleteMethod="DeleteCard"
            SelectMethod="GetCards" CssClass="table table-striped" border="0" GridLines="None"  ShowHeaderWhenEmpty="true" emptydatatext="ჩანაწერები ვერ მოიძებნა" >

            <Columns>

                <asp:TemplateField HeaderText="სახელი და გვარი">
                    <ItemTemplate>
                        <%# Item.FirstName+" "+Item.LastName %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="PersonalNr"
                    HeaderText="პირადი ნომერი" ReadOnly="True"
                    SortExpression="PersonalNr" />
                <asp:BoundField DataField="Gender.GenderName"
                    HeaderText="სქესი" ReadOnly="True"
                    SortExpression="Gender.GenderName" />

                <asp:BoundField DataField="BirthDate" DataFormatString="{0:yyyy-MM-dd}"
                    HeaderText="დაბადების თარიღი" ReadOnly="True"
                    SortExpression="BirthDate" />
                <asp:BoundField DataField="ValidityDate" DataFormatString="{0:yyyy-MM-dd}"
                    HeaderText="მოქმედების ვადა" ReadOnly="True"
                    SortExpression="ValidityDate" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <a class="btn btn-warning" href="/CreateEdit?id=<%#: Item.ID %>">რედაქტირება</a>
                         <asp:LinkButton ID="lnkdel" runat="server" Text="წაშლა" CommandName="Delete" CssClass="btn btn-danger"></asp:LinkButton>
                      
                    </ItemTemplate>
                </asp:TemplateField>

            </Columns>
        </asp:GridView>
    </div>
    <script>
        $(document).ready(function () {
            var hiddenValue = $("#MainContent_collapseField").val();
            if (hiddenValue != null && hiddenValue != "") {
                $("#searchPanel").collapse("show");
            }
        });
    </script>
</asp:Content>


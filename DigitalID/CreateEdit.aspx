<%@ Page Title="დამატება/რედაქტირება" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateEdit.aspx.cs" Inherits="DigitalID.TestAdd" %>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">

    <h2>დამატება/რედაქტირება</h2>
   
    <div class="row">
         <asp:Literal ID="errorDiv" runat="server" Visible="false">
            
        </asp:Literal>
       <div class="form-group">
            <label for="">სახელი</label>
            <asp:TextBox runat="server" ID="fNameInput" CssClass="form-control" required="required" ></asp:TextBox>
        
       </div>
         <div class="form-group">
            <label for="">გვარი</label>
            <asp:TextBox runat="server" ID="lNameInput" CssClass="form-control" required="required" ></asp:TextBox>        
       </div>
        <div class="form-group">
              <label for="">მოქალაქეობა</label>
                <asp:dropdownlist id="nationalityInput" runat="server"  CssClass="form-control" datatextfield="NationalityName"
                    datavaluefield="ID" >
                </asp:dropdownlist>        
          </div>
         <div class="form-group">
              <label for="">სქესი</label>
                <asp:dropdownlist id="genderInput" runat="server"  CssClass="form-control"  datatextfield="GenderName"
                    datavaluefield="ID" >
                </asp:dropdownlist>        
          </div>
           <div class="form-group">
            <label for="">პირადი ნომერი</label>
            <asp:TextBox runat="server" ID="pnInput" CssClass="form-control" required="required"  MaxLength="11" minlength="11" pattern="\d{11}" title="ზუსტად 11 ციფრი"></asp:TextBox>        
          </div>
        <div class="form-group">
            <label for="">დაბადების თარიღი</label>
            <asp:TextBox runat="server" ID="bDateInput" CssClass="form-control datepicker" required="required" ></asp:TextBox>        
          </div>
        <div class="form-group">
            <label for="">გაცემის თარიღი</label>
            <asp:TextBox runat="server" ID="issueDateInput" CssClass="form-control datepicker" required="required" ></asp:TextBox>        
          </div>
        <div class="form-group">
            <label for="">მოქმედების ვადა</label>
            <asp:TextBox runat="server" ID="validDateInput" CssClass="form-control datepicker" required="required" ></asp:TextBox>        
          </div>

        <div class="form-group">
              <label for="">დაბადების ადგილი</label>
                <asp:dropdownlist id="birthPlaceInput" runat="server"  CssClass="form-control" datatextfield="PlaceName"
                    datavaluefield="ID" >
                </asp:dropdownlist>        
          </div>
         <div class="form-group">
            <label for="">ბარათის ნომერი</label>
            <asp:TextBox runat="server" ID="cardNrInput" CssClass="form-control" required="required" ></asp:TextBox>        
       </div>

         <div class="form-group">
            <label for="">გამცემი ორგანო</label>
            <asp:TextBox runat="server" ID="issuerInput" CssClass="form-control" required="required" ></asp:TextBox>        
       </div>

       <asp:Button runat="server" Text="დამატება/რედაქტირება" CausesValidation="false" OnClick="AddOrUpdate"  CssClass="btn btn-success"/>
    </div>
       
</asp:Content>
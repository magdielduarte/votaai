<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Partido.ascx.cs" Inherits="Votaai.UserControl.Partido" %>

<div class="tab-pane active" id="Formpartido">
    <div id="edit-profile" class="form-horizontal">
        <asp:UpdatePanel ID="uppartido" runat="server">
            <ContentTemplate>
                <fieldset>

                    <div class="control-group">
                        <label class="control-label" for="username">Sigla</label>
                        <div class="controls">
                            <input type="text" class="span4 " style="width: 150px" id="pessigla" name="pessigla" runat="server" />
                            <input type="hidden" runat="server" id="hiddenpartido" />

                            <asp:Button Text="Pesquisar" CssClass="btn btn-success" ID="BtnPesquisar" runat="server" OnClick="BtnPesquisar_Click" />

                        </div>
                    </div>

                    <div class="control-group">
                        <label class="control-label" for="username">CNPJ</label>
                        <div class="controls">
                            <input type="text" class="span4" id="cpnjpartido" name="cnpj" runat="server" placeholder="99.999.999/9999-99">
                            <%--TODO: Revisar essa desgraça de regex do capeta--%>
                            <%--                    <asp:RegularExpressionValidator runat="server" ControlToValidate="cpnjpartido" ErrorMessage="Cnpj Inválido!" ValidationExpression="^( \d{2}?\d{3}?\d{3}?\d{4}?\d{2})$"></asp:RegularExpressionValidator>--%>
                        </div>
                        <!-- /controls -->
                    </div>
                    <!-- /control-group -->


                    <div class="control-group">
                        <label class="control-label" for="firstname">Nome</label>
                        <div class="controls">
                            <input type="text" class="span4" id="nomepartido" runat="server" name="nome" placeholder="Digite o nome completo do partido">
                        </div>
                        <!-- /controls -->
                    </div>
                    <!-- /control-group -->


                    <div class="control-group">
                        <label class="control-label" for="lastname">Sigla</label>
                        <div class="controls">
                            <input type="text" class="span4" id="siglapartido" runat="server" placeholder="Digite a sigla do partido">
                        </div>
                        <!-- /controls -->
                    </div>
                    <!-- /control-group -->


                    <div class="control-group">
                        <label class="control-label" for="email">Prefixo</label>

                        <div class="controls">
                                                        <asp:TextBox runat="server" MaxLength="2" CssClass="span4" ID="prefixopartido" placeholder="Digite o prefixo do partid. Ex: 13"></asp:TextBox>
                        </div>
                        <!-- /controls -->
                    </div>
                    <!-- /control-group -->

                    <div class="form-actions">

                        <asp:Button runat="server" ID="BtnCadPart" CssClass="btn btn-success" Text="Cadastrar" OnClick="BtnCadPart_Click" />
                        <asp:Button runat="server" ID="BtnCanPart" CssClass="btn" Text="Cancelar" OnClick="BtnCanPart_Click"></asp:Button>
                    </div>
                    <!-- /form-actions -->
                </fieldset>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</div>

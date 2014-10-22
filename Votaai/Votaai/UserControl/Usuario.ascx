<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Usuario.ascx.cs" Inherits="Votaai.UserControl.Usuario" %>

<div class="tab-pane" id="Formusuario">
    <div id="edit-profile" class="form-horizontal">
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <fieldset>

                    <div class="control-group">

                        <label class="control-label" for="username">Login</label>
                        <div class="controls">
                            <input type="text" class="span4 " style="width: 150px" id="peslogin" name="peslogin" runat="server" />
                            <asp:Button Text="Pesquisar" CssClass="btn btn-success" ID="BtnPesquisar" runat="server" OnClick="BtnPesquisar_Click" />
                            <input type="hidden" runat="server" id="hiddenusuario" />
                        </div>

                        <div class="control-group">
                            <label class="control-label" for="username">Login</label>
                            <div class="controls">
                                <input type="text" class="span4" id="userlogin" runat="server" name="login" placeholder="Login">
                                <input type="hidden" id="idhidden" runat="server" />

                            </div>
                            <!-- /controls -->
                        </div>
                        <!-- /control-group -->

                        <div class="control-group">
                            <label class="control-label" for="email">Senha</label>
                            <div class="controls">
                                <input type="password" runat="server" class="span4" id="usersenha" placeholder="Senha">
                            </div>
                            <!-- /controls -->
                        </div>
                        <!-- /control-group -->

                        <div class="control-group">
                            <label class="control-label" for="email">Repita a senha</label>
                            <div class="controls">
                                <input type="password" class="span4" runat="server" id="usersenharepitida" name="senharepitida" placeholder="Repita a senha">
                            </div>
                            <!-- /controls -->
                        </div>
                        <!-- /control-group -->

                        <div class="form-actions">
                            <asp:Button runat="server" ID="BtnCadUsu" CssClass="btn btn-success" Text="Cadastrar" OnClick="BtnCadUsu_Click" />
                            <asp:Button runat="server" ID="BtnCanUsu" CssClass="btn" Text="Cancelar" OnClick="BtnCanUsu_Click"></asp:Button>
                        </div>
                        <!-- /form-actions -->
                </fieldset>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</div>


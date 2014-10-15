<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Partido.ascx.cs" Inherits="Votaai.UserControl.Partido" %>

<div class="tab-pane active" id="Formpartido">
    <div id="edit-profile" class="form-horizontal">
        <fieldset>
            <div class="control-group">
                <label class="control-label" for="username">Sigla</label>
                <div class="controls">
                    <input type="text" class="span4 " style="width: 150px" id="pessigla" name="pessigla" />
                    <a href="#" class="btn btn-sucess"><i class="icon-search"></i>pesquisar</a>
                </div>
            </div>

            <div class="control-group">
                <label class="control-label" for="username">CNPJ</label>
                <div class="controls">
                    <input type="text" class="span4" id="cpnj" name="cnpj" placeholder="99.999.999/9999-99">
                </div>
                <!-- /controls -->
            </div>
            <!-- /control-group -->


            <div class="control-group">
                <label class="control-label" for="firstname">Nome</label>
                <div class="controls">
                    <input type="text" class="span4" id="nome" name="nome" placeholder="Digite o nome completo do partido">
                </div>
                <!-- /controls -->
            </div>
            <!-- /control-group -->


            <div class="control-group">
                <label class="control-label" for="lastname">Sigla</label>
                <div class="controls">
                    <input type="text" class="span4" id="sigla" placeholder="Digite a sigla do partido">
                </div>
                <!-- /controls -->
            </div>
            <!-- /control-group -->


            <div class="control-group">
                <label class="control-label" for="email">Prefixo</label>
                <div class="controls">
                    <input type="number" class="span4" id="prefixo" placeholder="Digite o prefixo do partid. Ex: 13">
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
    </div>
</div>

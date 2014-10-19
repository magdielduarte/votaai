<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Candidato.ascx.cs" Inherits="Votaai.UserControl.Candidato" %>

<div class="tab-pane" id="Formcandidato">
    <div id="edit-profile" class="form-horizontal">
        <fieldset>

            <div class="control-group">
                <label class="control-label" for="username">Nome</label>
                <div class="controls">
                    <input type="text" class="span4" runat="server" id="nomecandidato" name="nome" placeholder="Digite o nome do candidato">
                    <input type="hidden" runat="server" id="hiddencand" />
                </div>
                <!-- /controls -->
            </div>
            <!-- /control-group -->

            <div class="control-group">
                <label class="control-label" for="email">Número</label>
                <div class="controls">
                    <%--                    <input type="number" runat="server" class="span4" id="numero" placeholder="Digite o numero do candidato">--%>
                    <asp:TextBox runat="server" type="number" CssClass="span4" ID="numero" placeholder="Digite o número do candidato"></asp:TextBox>
                </div>
                <!-- /controls -->
            </div>
            <!-- /control-group -->

            <div class="control-group">
                <label class="control-label" for="cargo">Cargo</label>
                <div class="controls">
                    <select name="" runat="server" id="selectcargo" class="span4">
                        <option value=""></option>
                        <option value="1">Presidente</option>
                        <option value="2">Senador</option>
                        <option value="3">Governador</option>
                        <option value="4">Deputado Federal</option>
                        <option value="5">Deputado Estadual</option>
                    </select>
                </div>
                <!-- /controls -->
            </div>
            <!-- /control-group -->
            <div class="control-group" id="vice" style="display: none;">
                <label class="control-label" for="cargo">Vice</label>
                <div class="controls">
                    <input type="text" runat="server" class="span4" id="txtvice" placeholder="Digite o nome do vice">
                </div>
                <!-- /controls -->
            </div>
            <div class="control-group" id="suplente" style="display: none;">
                <label class="control-label" for="suplente1">1° suplemente</label>
                <div class="controls" style="margin-bottom: 20px;">
                    <input type="text" class="span4" id="txtsuplente1" runat="server" placeholder="Digite o nome do 1° suplente">
                </div>
                <label class="control-label" for="suplente2">2° suplemente</label>
                <div class="controls">
                    <input type="text" class="span4" id="txtsuplente2" runat="server" placeholder="Digite o nome do 2° suplente">
                </div>
                <!-- /controls -->
            </div>
            <!-- /control-group -->

            <div class="control-group">
                <label class="control-label" for="email">Foto</label>
                <div class="controls">
                    <input type="file" class="span4" id="img">
                </div>
                <!-- /controls -->
            </div>
            <!-- /control-group -->

            <div class="control-group">
                <label class="control-label" for="email">Partido</label>
                <div class="controls">
                    <select name="" runat="server" id="selectpartido" class="span4">
                    </select>
                </div>
                <!-- /controls -->
            </div>
            <!-- /control-group -->

            <div class="form-actions">

                <asp:Button runat="server" ID="BtnCadCand" CssClass="btn btn-success" Text="Cadastrar" OnClick="BtnCadCand_Click" />
                <asp:Button runat="server" ID="BtnCanCand" CssClass="btn" Text="Cancelar" OnClick="BtnCanCand_Click"></asp:Button>
            </div>
            <!-- /form-actions -->

        </fieldset>
    </div>
</div>


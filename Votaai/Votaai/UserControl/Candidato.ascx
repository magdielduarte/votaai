<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Candidato.ascx.cs" Inherits="Votaai.UserControl.Candidato" %>

<div class="tab-pane" id="Formcandidato">
    <div id="edit-profile" class="form-horizontal">
        <fieldset>

            <div class="control-group">
                <label class="control-label" for="username">Nome</label>
                <div class="controls">
                    <input type="text" class="span4" id="nomecandidato" name="nome" placeholder="Digite o nome do candidato">
                </div>
                <!-- /controls -->
            </div>
            <!-- /control-group -->

            <div class="control-group">
                <label class="control-label" for="email">Número</label>
                <div class="controls">
                    <input type="number" class="span4" id="numero" placeholder="Digite o numero do candidato">
                </div>
                <!-- /controls -->
            </div>
            <!-- /control-group -->

            <div class="control-group">
                <label class="control-label" for="cargo">Cargo</label>
                <div class="controls">
                    <select name="" id="selectcargo" class="span4">
                        <option value=""></option>
                        <option value="1">Presidente</option>
                        <option value="2">Senador</option>
                        <option value="3">Governador</option>
                    </select>
                </div>
                <!-- /controls -->
            </div>
            <!-- /control-group -->
            <div class="control-group" id="vice" style="display: none;">
                <label class="control-label" for="cargo">Vice</label>
                <div class="controls">
                    <input type="text" class="span4" id="txtvice" placeholder="Digite o nome do vice">
                </div>
                <!-- /controls -->
            </div>
            <div class="control-group" id="suplente" style="display: none;">
                <label class="control-label" for="suplente1">1° suplemente</label>
                <div class="controls" style="margin-bottom: 20px;">
                    <input type="text" class="span4" id="Text1" placeholder="Digite o nome do 1° suplente">
                </div>
                <label class="control-label" for="suplente2">2° suplemente</label>
                <div class="controls">
                    <input type="text" class="span4" id="Text2" placeholder="Digite o nome do 2° suplente">
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
                    <select name="" id="" class="span4">
                        <option value="">PSDB</option>
                        <option value="">PT</option>
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


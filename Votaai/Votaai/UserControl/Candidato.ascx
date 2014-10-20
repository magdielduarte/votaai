<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Candidato.ascx.cs" Inherits="Votaai.UserControl.Candidato" %>

<div class="tab-pane" id="Formcandidato">
    <div id="edit-profile" class="form-horizontal">
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <fieldset>

                    <div class="control-group">

                        <label class="control-label" for="username">Número</label>
                        <div class="controls">
                            <input type="text" class="span4 " style="width: 150px" id="pesnumero" name="pesnumero" runat="server" />
                            <asp:Button Text="Pesquisar" CssClass="btn btn-success" ID="BtnPesquisar" runat="server" OnClick="BtnPesquisar_Click" />
                        </div>
                    </div>

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
                        <label class="control-label" for="email">Partido</label>
                        <div class="controls">

                            <asp:DropDownList runat="server" ID="selectpartido" AutoPostBack="true" CssClass="span4" OnSelectedIndexChanged="selectpartido_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>
                        <!-- /controls -->
                    </div>
                    <!-- /control-group -->


                    <div class="control-group">
                        <label class="control-label" for="email">Número</label>
                        <div class="controls">
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
                            <asp:FileUpload runat="server" ID="FileFotoCand" CssClass="span4"></asp:FileUpload>
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

            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</div>

<script>
    window.onload = function () {
        var select = document.getElementById('Candidato_selectcargo'),
             vice = document.getElementById('vice'),
             suplente = document.getElementById('suplente');

        function none() {
            vice.style.display = 'none';
            suplente.style.display = 'none';
        }

        none();

        select.onchange = function () {

            if (select.value == '1' || select.value == '3') {
                none();
                vice.style.display = 'block';
            }
            else if (select.value == '2') {
                none();
                suplente.style.display = 'block';
            }
            else {
                none();
            }
        };
    };
</script>


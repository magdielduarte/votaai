<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Candidato.ascx.cs" Inherits="Votaai.UserControl.Candidato" %>

<div class="tab-pane" id="Formcandidato">
    <div id="edit-profile" class="form-horizontal">
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <fieldset>
                    <div id="le-alert" style="display: none;" class="alert alert-danger alert-block fade">
                        <button href="#" type="button" onclick="desativadiv()" class="close">&times;</button>
                        <h4>Alerta!</h4>
                        <asp:Label runat="server" ID="lbldanger" CssClass="p"></asp:Label>
                    </div>

                    <div id="le-sucess" style="display: none;" class="alert alert-sucess alert-block fade">
                        <button href="#" type="button" onclick="desativadiv()" class="close">&times;</button>
                        <h4>Mensagem!</h4>
                        <asp:Label runat="server" ID="LblSucess" CssClass="p"></asp:Label>
                    </div>

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
                            <asp:TextBox runat="server" ID="nomecandidato" CssClass="span4" name="nome" placeholder="Digite o nome do candidato"></asp:TextBox>

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
                        <label class="control-label" for="cargo">Cargo</label>
                        <div class="controls">

                            <asp:DropDownList runat="server" AutoPostBack="true" ID="selectcargo" CssClass="span4" OnSelectedIndexChanged="selectcargo_SelectedIndexChanged">
                                <asp:ListItem Value="" Text=""></asp:ListItem>
                                <asp:ListItem Value="1" Text="Presidente"></asp:ListItem>
                                <asp:ListItem Value="2" Text="Senador"></asp:ListItem>
                                <asp:ListItem Value="3" Text="Governador"></asp:ListItem>
                                <asp:ListItem Value="4" Text="Deputado Federal"></asp:ListItem>
                                <asp:ListItem Value="5" Text="Deputado Estadual"></asp:ListItem>
                            </asp:DropDownList>


                        </div>
                        <!-- /controls -->
                    </div>

                    <div class="control-group" runat="server" id="Div1">
                        <label class="control-label" for="cargo">Estado</label>
                        <div class="controls">
                            <asp:DropDownList runat="server" ID="selectestado" Width="250">
                                <asp:ListItem Value=""></asp:ListItem>
                                <asp:ListItem Value="AC">Acre</asp:ListItem>
                                <asp:ListItem Value="AL">Alagoas</asp:ListItem>
                                <asp:ListItem Value="AM">Amazonas</asp:ListItem>
                                <asp:ListItem Value="AP">Amapá</asp:ListItem>
                                <asp:ListItem Value="BA">Bahia</asp:ListItem>
                                <asp:ListItem Value="CE">Ceará</asp:ListItem>
                                <asp:ListItem Value="DF">Distrito Federal</asp:ListItem>
                                <asp:ListItem Value="ES">Espírito Santo</asp:ListItem>
                                <asp:ListItem Value="GO">Goiás</asp:ListItem>
                                <asp:ListItem Value="MA">Maranhão</asp:ListItem>
                                <asp:ListItem Value="MG">Minas Gerais</asp:ListItem>
                                <asp:ListItem Value="MS">Mato Grosso do Sul</asp:ListItem>
                                <asp:ListItem Value="MT">Mato Grosso</asp:ListItem>
                                <asp:ListItem Value="PA">Pará</asp:ListItem>
                                <asp:ListItem Value="PB">Paraíba</asp:ListItem>
                                <asp:ListItem Value="PE">Pernambuco</asp:ListItem>
                                <asp:ListItem Value="PI">Piauí</asp:ListItem>
                                <asp:ListItem Value="PR">Paraná</asp:ListItem>
                                <asp:ListItem Value="RJ">Rio de Janeiro</asp:ListItem>
                                <asp:ListItem Value="RN">Rio Grande do Norte</asp:ListItem>
                                <asp:ListItem Value="RO">Rondônia</asp:ListItem>
                                <asp:ListItem Value="RR">Roraima</asp:ListItem>
                                <asp:ListItem Value="RS">Rio Grande do Sul</asp:ListItem>
                                <asp:ListItem Value="SC">Santa Catarina</asp:ListItem>
                                <asp:ListItem Value="SE">Sergipe</asp:ListItem>
                                <asp:ListItem Value="SP">São Paulo</asp:ListItem>
                                <asp:ListItem Value="TO">Tocantins</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <!-- /controls -->
                    </div>

                    <!-- /control-group -->
                    <div class="control-group" runat="server" id="vice" style="display: none;">
                        <label class="control-label" for="cargo">Vice</label>
                        <div class="controls">
                            <input type="text" runat="server" class="span4" id="txtvice" placeholder="Digite o nome do vice">
                        </div>
                        <!-- /controls -->
                    </div>
                    <div class="control-group" id="suplente" runat="server" style="display: none;">
                        <label class="control-label" for="suplente1">1° Suplente</label>
                        <div class="controls" style="margin-bottom: 20px;">
                            <input type="text" class="span4" id="txtsuplente1" runat="server" placeholder="Digite o nome do 1° suplente">
                        </div>
                        <label class="control-label" for="suplente2">2° Suplente</label>
                        <div class="controls">
                            <input type="text" class="span4" id="txtsuplente2" runat="server" placeholder="Digite o nome do 2° suplente">
                        </div>
                        <!-- /controls -->
                    </div>
                    <!-- /control-group -->
                    <div class="control-group">
                        <label class="control-label" for="email">Número</label>
                        <div class="controls">
                            <asp:TextBox MaxLength="2" Width="30" ReadOnly="true" Enabled="false" CausesValidation="false" runat="server" CssClass="span4" ID="numeropartido"></asp:TextBox>
                            <asp:TextBox MaxLength="3" Width="55" CausesValidation="false" runat="server" CssClass="span4" ID="numerocand"></asp:TextBox>
                            <asp:RegularExpressionValidator SetFocusOnError="true" runat="server" ID="valNumbersOnly" ControlToValidate="numerocand" Display="Dynamic" ErrorMessage="Apenas números são permitidos!" ValidationExpression="(^([0-9]*|\d*\d{1}?\d*)$)" ForeColor="Red"></asp:RegularExpressionValidator>

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


        <input type="hidden" runat="server" id="hiddencand" />
    </div>
</div>

<script>
    window.onload = function () {
        var select = document.getElementById('Candidato_selectcargo'),
             vice = document.getElementById('Candidato_vice'),
             suplente = document.getElementById('Candidato_suplente');

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

<script type="text/javascript">
    function desativadiv(id) {

        $('#' + id).css('display', 'none'); // hides alert with Bootstrap CSS3 implem
    }


</script>

<script type="text/javascript">
    function ativadiv(id) {
        console.log("Diel Simpático");
        alert("Túlio Lindão");
        $(id).removeAttr('style').fadeIn(20000).addClass('in').delay(1000).fadeOut(1500); // shows alert with Bootstrap CSS3 implem
    }
</script>



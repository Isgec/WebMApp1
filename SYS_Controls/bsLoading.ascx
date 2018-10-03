<%@ Control Language="VB" AutoEventWireup="false"%>
		<script type="text/javascript">
			function hideProcessingMPV(ev,e) {
			  var mPB = $find('mpelg');
			  mPB.hide();
			  if (e.get_error() != undefined) {
			    var ex = e.get_error();
			    try { alert(ex.message.split(':')[1]); } catch (exc) { alert(e.get_error()); }
				}
				e.set_errorHandled(true);
				return false;
			}
			function showProcessingMPV(ev) {
				var mPB = $find('mpelg');
				mPB.show();
				return false;
			}
		</script>

		<asp:Label ID="dummy" runat="server" Style="display: none"></asp:Label>
		<asp:Panel ID="pnl1" runat="server" Height="100px" Width="300px" Style="display: none">
			<table width="100%">
				<tr>
					<td>
						<input type="image" id="cmdClose0" runat="server" style="height:18px; width:18px;display:none;" onclick="return hideProcessingMPV();" alt="Close" title="Close" src="../App_Themes/Default/Images/closeWindow.png" />
					</td>
				</tr>
				<tr>
					<td  style="height: 75px; vertical-align:middle; text-align:center">
					  <asp:Image ID="imgLoading" runat="server" AlternateText="Processing" ImageUrl="~/App_Themes/Default/Images/Progress1.gif" />
					</td>
				</tr>
			</table>
		</asp:Panel>
		<AJX:ModalPopupExtender ID="pPopup" TargetControlID="dummy" BackgroundCssClass="modalBackground" BehaviorID="mpelg" CancelControlID="cmdClose0" OkControlID="dummy" PopupControlID="pnl1" runat="server">
		</AJX:ModalPopupExtender>

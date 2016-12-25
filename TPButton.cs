using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFDGameScriptInterface;

namespace SFD.Teletransportación.porBoton
{
    public class TPButton
    {
        /*
        * author: XHomie 
        * description: Teletransportation by Button
        * version: v0.1
        * license: Creative Commons
        * authorized for any official use, update and share for new versions to: LennyShogy 
        */

        private readonly Boolean TPBUTTON_EFFECTS = true;
        private readonly int AREA_RANGE = 8;
        /// <summary>
        /// Funcion que permite teletransportar "Players" usando como referencia:
        /// 1 Boton, 1 ScriptTrigger
        /// Boton: Sera el que apunte al ScriptTrigger para que aquel llame al metodo
        /// ScriptTrigger: Sera el que llame al metodo y ademas sea usado como referencia donde teletransportara al personaje
        /// </summary>
        /// <param name="args">Trigger invocado con Objetos del que llama y el llamado</param>

        public void TP_Button(TriggerArgs args)
        {
            if (args.Sender is IObject)
            {
                IObject ob = (IObject)args.Caller;
                Vector2 ps1 = ((IObject)args.Sender).GetWorldPosition();
                Vector2 ps2 = ob.GetWorldPosition();
                Area a = new Area(ps1.Y + AREA_RANGE, ps1.X - AREA_RANGE, ps1.Y - AREA_RANGE, ps1.X + AREA_RANGE);

                foreach (IObject obs in GameScriptInterface.Game.GetObjectsByArea(a))
                {
                    if (obs is IPlayer)
                    {
                        TPEffect("S_P", ps1);
                        obs.SetWorldPosition(ps2);
                        TPEffect("TR_D", ps2);
                    }
                }
            }
        }
        public void TPEffect(String type, Vector2 ps)
        {
            if(TPBUTTON_EFFECTS)
                GameScriptInterface.Game.PlayEffect(type, ps);
        }
    }
}

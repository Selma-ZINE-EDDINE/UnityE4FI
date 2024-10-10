using UnityEngine;

namespace KartGame.KartSystems {

    public class KeyboardInput2 : BaseInput
    {
        public string TurnInputName = "Horizontal2";
        public string AccelerateButtonName = "Accelerate2";
        public string BrakeButtonName = "Brake2";

        public override InputData GenerateInput() {
            return new InputData
            {
                Accelerate = Input.GetButton(AccelerateButtonName),
                Brake = Input.GetButton(BrakeButtonName),
                TurnInput = Input.GetAxis("Horizontal2")
            };
        }
    }
}

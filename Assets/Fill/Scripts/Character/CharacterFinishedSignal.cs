

namespace GameSDK.Scripts.Character
{
    public struct CharacterFinishedSignal
    {
        public CharacterMono Character;
        public CharacterFinishedSignal(CharacterMono character)
        {
            Character = character;
        }
    }
}
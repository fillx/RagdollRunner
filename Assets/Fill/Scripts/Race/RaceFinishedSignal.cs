using System.Collections.Generic;

public struct RaceFinishedSignal
{
   public  readonly List<CharacterMono> FinishedCharacters;

   public RaceFinishedSignal(List<CharacterMono> finishedCharacters)
   {
      FinishedCharacters = finishedCharacters;
   }
}
using System;
using MilitaryElite.Contracts;
using MilitaryElite.Enumerations;
using MilitaryElite.Exceptions;

namespace MilitaryElite.Models
{
    public class Mission : IMission
    {
        public Mission(string codeName, string state)
        {
            this.CodeName = codeName;
            this.State = this.TryParseState(state);
        }
        public string CodeName { get; private set; }

        public State State { get; private set; }
        public void CompleteMission()
        {
            if(this.State==State.Finished)
            {
                throw new InvalidMissionCompletionException();
            }
            this.State = State.Finished;
        }

        private State TryParseState(string stateStr)
        {
            State state;
            bool parsed = Enum.TryParse<State>(stateStr, out state);
            if(!parsed)
            {
                throw new InvalidMissionStateException();
            }
            return state;

        }

        public override string ToString()
        {
            return $"Code Name: {this.CodeName} State: {this.State}";
        }
    }
}

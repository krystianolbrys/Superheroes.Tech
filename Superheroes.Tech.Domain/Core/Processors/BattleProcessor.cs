using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Superheroes.Tech.Domain.Core.Entities;

namespace Superheroes.Tech.Domain.Core.Processors
{
    public class BattleResultVo
    {
        public BattleResultVo(bool success, CharacterEntity? characterEntity = null, string? failReason = null)
        {
            Success = success;
            CharacterEntity = characterEntity;
            FailReason = failReason;
        }

        public bool Success { get; private set; }
        public CharacterEntity? CharacterEntity { get; private set; }
        public string? FailReason { get; private set; }
    }

    public class BattleProcessor
    {
        public BattleResultVo Fight(CharacterEntity oponent1, CharacterEntity oponent2)
        {
            if (oponent1.Type.Equals(oponent2.Type))
            {
                return new BattleResultVo(false, null, "characters of the same type should not fight");
            }

            if (!oponent1.Type.Equals(oponent2.Type))
            {
                var oponenets = new List<CharacterEntity>() { oponent1, oponent2 };
                var win  = oponenets.OrderByDescending(op => op.Score.Value).First();

                return new BattleResultVo(true, win, null);
            }

            throw new Exception("Implement business exception for that unhandled business case");
        }
    }
}

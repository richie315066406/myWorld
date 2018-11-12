using GameFramework;

namespace ProjectZGL
{
    public class VarPlayerInfo : Variable<PlayerInfo>
    {
        public VarPlayerInfo(){

        }

        public VarPlayerInfo(PlayerInfo value)
            :base(value){
                
        }

        public static implicit operator VarPlayerInfo(PlayerInfo value){
            return new VarPlayerInfo(value);
        }

        public static implicit operator PlayerInfo(VarPlayerInfo value){
            return value.Value;
        }

    }
}

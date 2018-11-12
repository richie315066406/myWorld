using GameFramework;

namespace ProjectZGL
{
    public class VarGameInfo : Variable<GameInfo>
    {
        public VarGameInfo(){

        }

        public VarGameInfo(GameInfo value)
            :base(value){
                
        }

        public static implicit operator VarGameInfo(GameInfo value){
            return new VarGameInfo(value);
        }

        public static implicit operator GameInfo(VarGameInfo value){
            return value.Value;
        }

    }
}

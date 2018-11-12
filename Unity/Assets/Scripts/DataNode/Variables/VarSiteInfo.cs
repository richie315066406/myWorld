using GameFramework;

namespace ProjectZGL
{
    public class VarSiteInfo : Variable<SiteInfo>
    {
        public VarSiteInfo(){

        }

        public VarSiteInfo(SiteInfo value)
            :base(value){
                
        }

        public static implicit operator VarSiteInfo(SiteInfo value){
            return new VarSiteInfo(value);
        }

        public static implicit operator SiteInfo(VarSiteInfo value){
            return value.Value;
        }

    }
}

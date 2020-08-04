using System;
using System.Collections.Generic;
using System.Text;

namespace Design_Pattern.Abstract_Factory_Pattern
{
    class AFP
    {
    }

    interface ISmartPhone
    {
        string GetModelDetails();
    }

    interface INormalPhone
    {
        string GetModelDetails();
    }


    /// <summary>
    ///  Mobile model and details
    /// </summary>
    /// 
    class Nokiapixel : ISmartPhone
    {
        public string GetModelDetails()
        {
            return "Model: Nokia Pixel\nRAM: 3GB\nCamera: 8MP\n";
        }
    }

    class Nokia1600 : INormalPhone
    {
        public string GetModelDetails()
        {
            return "Model: Nokia 1600\nRAM: NA\nCamera: NA\n";
        }
    }

    /// <summary>
    /// Samsung model and details
    /// </summary>
    class SamsungGalaxy : ISmartPhone
    {
        public string GetModelDetails()
        {
            return "Model: Samsung Galaxy\nRAM: 2GB\nCamera: 13MP\n";
        }
    }

    class SamsungGuru : INormalPhone
    {
        public string GetModelDetails()
        {
            return "Model: Samsung Guru\nRAM: NA\nCamera: NA\n";
        }
    }


    interface IMobilePhone
    {
        ISmartPhone GetSmartPhone();
        INormalPhone GetNormalPhone();
    }


    // Actual Mobile company class 

    class Nokia : IMobilePhone
    {
        public INormalPhone GetNormalPhone()
        {
            return new Nokia1600();
        }

        public ISmartPhone GetSmartPhone()
        {
            return new Nokiapixel();
        }
    }


    class Samsung : IMobilePhone
    {
        public INormalPhone GetNormalPhone()
        {
            return new SamsungGuru();
        }

        public ISmartPhone GetSmartPhone()
        {
            return new SamsungGalaxy();
        }
    }


    // create client application

    class MobileClient
    {
        ISmartPhone smartPhone;
        INormalPhone normalPhone;
        public MobileClient(IMobilePhone mobilePhone)
        {
            normalPhone = mobilePhone.GetNormalPhone();
            smartPhone = mobilePhone.GetSmartPhone();
        }

        public string GetSmartPhoneModelDetails()
        {
            return smartPhone.GetModelDetails();
        }

        public string GetNormalPhoneModelDetails()
        {
            return normalPhone.GetModelDetails();
        }
    }
}

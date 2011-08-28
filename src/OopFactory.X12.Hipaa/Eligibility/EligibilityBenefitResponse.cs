﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Serialization;
using OopFactory.X12.Hipaa.Common;

namespace OopFactory.X12.Hipaa.Eligibility
{
    [XmlRoot(Namespace = "http://www.oopfactory.com/2011/XSL/Hipaa")]
    public class EligibilityBenefitResponse : EligibilityBenefitBase
    {
        public EligibilityBenefitResponse()
        {
            if (Benefits == null) Benefits = new List<EligibilityBenefit>();
        }

        [XmlAttribute]
        public string TransactionControlNumber { get; set; }


        [XmlElement(ElementName = "Benefit")]
        public List<EligibilityBenefit> Benefits { get; set; }



        #region Serialization Methods
        public string Serialize()
        {
            StringWriter writer = new StringWriter();
            new XmlSerializer(typeof(EligibilityBenefitResponse)).Serialize(writer, this);
            return writer.ToString();
        }

        public static EligibilityBenefitResponse Deserialize(string xml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(EligibilityBenefitResponse));
            return (EligibilityBenefitResponse)serializer.Deserialize(new StringReader(xml));

        }

        #endregion
    }

}

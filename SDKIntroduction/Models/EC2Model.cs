using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Amazon.EC2;
using Amazon.EC2.Model;

namespace SDKIntroduction.Models
{
    public class EC2Model
    {
        public AmazonEC2Client client = new AmazonEC2Client();

        public void CreateInstance()
        {
            string groupId = "sg-75572c10";
            string imageId = "ami-54052327";
            string keyPairName = "Conners Key";

            List<string> groupsList = new List<string>()
            {
                groupId
            };
            var launchRequest = new RunInstancesRequest()
            {
                ImageId = imageId,
                InstanceType = InstanceType.T2Micro,
                MinCount = 1,
                MaxCount = 1,
                KeyName = keyPairName,
                SecurityGroupIds = groupsList,
            };
            var launchresponse = client.RunInstances(launchRequest);
            //Name the Instance
            var myInstance = launchresponse.Reservation.Instances[0].InstanceId;
            var tagRequests = new CreateTagsRequest();
            tagRequests.Resources.Add(myInstance);
            tagRequests.Tags.Add(new Tag { Key = "Name", Value = "SDKIntroductionInstance" });
            client.CreateTags(tagRequests);

        }
    }
}
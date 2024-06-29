using Google.Apis.Auth.OAuth2;
using Google.Apis.Storage.v1.Data;
using Google.Cloud.Storage.V1;
using MimeKit.Cryptography;
using System;
using System.IO;
using System.Threading.Tasks;

namespace On_Demand_Tutor_UI
{
    public class FireBaseStorage
    {
        private readonly string _bucketName;
        private readonly StorageClient _storageClient;

        public FireBaseStorage()
        {
            var credential = GoogleCredential.FromFile("Firebase/your-account-service.json");
            _storageClient = StorageClient.Create(credential);
            _bucketName = "ondemandtutor-8e388.appspot.com";
        }

        public async Task<string> UploadFileAsync(Stream fileStream, string fileName)
        {
            var storageObject = await _storageClient.UploadObjectAsync(_bucketName, fileName, null, fileStream);

            storageObject.Acl = new List<ObjectAccessControl>
            {
                new ObjectAccessControl
                {
                    Bucket = _bucketName,
                    Entity = "allUsers",
                    Role = "READER"
                }
            };
            await _storageClient.UpdateObjectAsync(storageObject);

            return storageObject.MediaLink;
        }

        public string GetSignedUrl(string fileName, TimeSpan duration)
        {
            UrlSigner urlSigner = UrlSigner.FromServiceAccountPath("Firebase/service-account-file.json");
            return urlSigner.Sign(_bucketName, fileName, duration);
        }
    }
}
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Azure.Storage;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using System;
using Xunit;


namespace XUnitTestProject1
{
    public class BlobTest
    {

        [Fact]
        public void UploadFile()
        {
            string connectionString = "DefaultEndpointsProtocol=https;AccountName=polichecksvc;AccountKey=+qitaIPghvVZQIm410FXCmeRJaHet9Ykj9G343ZSGbeyvaMpFCkEKZSwqiJwDMz/u0gpyihfzPmpqf7k54F9dQ==;EndpointSuffix=core.windows.net";
            string containerName = "blobtest";
            string blobName = "hello.docx";
           string filePath = @"C:\Users\v-qiazhe\Desktop\hello.docx";

            // Get a reference to a container named "sample-container" and then create it
            BlobContainerClient container = new BlobContainerClient(connectionString, containerName);


            // Get a reference to a blob named "sample-file" in a container named "sample-container"
            BlobClient blob = container.GetBlobClient(blobName);
           // blob.DownloadTo(@"C:\Users\v-qiazhe\Desktop");
            // Upload local file
           blob.Upload(filePath);
        }

        [Fact]
        public void DownloadFile()
        {
            string connectionString = "DefaultEndpointsProtocol=https;AccountName=polichecksvc;AccountKey=+qitaIPghvVZQIm410FXCmeRJaHet9Ykj9G343ZSGbeyvaMpFCkEKZSwqiJwDMz/u0gpyihfzPmpqf7k54F9dQ==;EndpointSuffix=core.windows.net";
            string containerName = "blobtest";
            BlobContainerClient container = new BlobContainerClient(connectionString, containerName);
            BlobClient blob = container.GetBlobClient("hello.docx");
            BlobDownloadInfo download = blob.Download();
            using (FileStream file = File.OpenWrite(@"C:\Users\v-qiazhe\Desktop\ttt.docx"))
            {
                download.Content.CopyTo(file);
            }
        }

        [Fact]
        public void DownloadImage()
        {

           var x= new BlobClient(new Uri("https://polichecksvc.blob.core.windows.net/blobtest/sample-blob.docx")).DownloadTo(@"C:\Users\v-qiazhe\Desktop\xxxx.docx");

        }
    }
}

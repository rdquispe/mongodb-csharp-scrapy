using System;
using System.Collections.Generic;
using System.Linq;
using HtmlAgilityPack;
using mongocsharp.Db;
using mongocsharp.Models;

namespace mongocsharp.Scrapy
{
    public class MetalArchives
    {
        public MetalArchives() { }

        MongoDb mongo = new MongoDb();

        public void SaveKingDiamond()
        {
            HtmlWeb web = new HtmlWeb();
            HtmlDocument metalArchiveBand = web.Load("https://www.metal-archives.com/bands/King_Diamond/255");
            
            var name = metalArchiveBand.DocumentNode.SelectSingleNode("//*[@id='band_info']/h1").InnerText.Trim();
            var country = metalArchiveBand.DocumentNode.SelectSingleNode("//*[@id='band_stats']/dl[1]/dd[1]/a").InnerText.Trim();
            var location = metalArchiveBand.DocumentNode.SelectSingleNode("//*[@id='band_stats']/dl[1]/dd[2]").InnerText.Trim();
            var status = metalArchiveBand.DocumentNode.SelectSingleNode("//*[@id='band_stats']/dl[1]/dd[3]").InnerText.Trim();
            var formedIn = metalArchiveBand.DocumentNode.SelectSingleNode("//*[@id='band_stats']/dl[1]/dd[4]").InnerText.Trim();
            var genre = metalArchiveBand.DocumentNode.SelectSingleNode("//*[@id='band_stats']/dl[2]/dd[1]").InnerText.Trim();
            var lyrical = metalArchiveBand.DocumentNode.SelectSingleNode("//*[@id='band_stats']/dl[2]/dd[2]").InnerText.Trim();
            var label = metalArchiveBand.DocumentNode.SelectSingleNode("//*[@id='band_stats']/dl[2]/dd[3]/a").InnerText.Trim();
            var comment = metalArchiveBand.DocumentNode.SelectSingleNode("//*[@id='band_info']/div[3]").InnerText.Trim();
            var yearsActive = metalArchiveBand.DocumentNode.SelectSingleNode("//*[@id='band_stats']/dl[3]/dd").InnerText.Trim();

            Band band = new Band();
            band.Name = name;
            band.Status = status;
            band.Country = country;
            band.FormedIn = formedIn;
            band.Genre = genre;
            band.Lyrical = lyrical;
            band.YearsActive = yearsActive;
            band.Label = label;
            band.Location = location;
            band.Comment = comment;

            List<Member> members = new List<Member>();
            foreach (var member in metalArchiveBand.DocumentNode.SelectNodes("//tr[@class='lineupRow']"))
            {
                var lineupRow = member.SelectNodes("td").ToList();
                members.Add(new Member
                {
                    Name = lineupRow[0].InnerText.Trim(),
                    Description = lineupRow[1].InnerText.Trim().Replace("&nbsp;", "")
                });
            }
            band.Members = members;

            List<Album> albums = new List<Album>();
            HtmlDocument metalArchiveDiscography = web.Load("https://www.metal-archives.com/band/discography/id/255/tab/all");
            HtmlNode discographies = metalArchiveDiscography.DocumentNode.SelectSingleNode("//table[@class='display discog']/tbody");
            foreach(var discography in discographies.Descendants("tr").ToList())
            {
                var information = discography.SelectNodes("td").ToList();
                albums.Add(new Album
                {
                    Name = information[0].InnerText.Trim(),
                    @Type = information[1].InnerText.Trim(),
                    Year = information[2].InnerText.Trim()
                });
            }
            band.Albums = albums;

            mongo.insertOne<Band>("band", band);
        }

    }
}

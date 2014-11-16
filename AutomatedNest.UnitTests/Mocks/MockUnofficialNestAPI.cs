﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomatedNest.NestDataObjects;
using Newtonsoft.Json;

namespace AutomatedNest.UnofficialNestAPI
{
    public class MockUnofficialNestAPI : IUnofficialNestAPI
    {
        public NestAPICredentialsResponse postLoginRequest(string username, string password)
        {
            NestAPICredentialsResponse response = new NestAPICredentialsResponse();
            
            if (username == "abc123" && password == "xyz987")
            {
                response.access_token = "abcdefghijklmnopqrstuvwxyz1234567890";
                response.email = "test@email.com";
                response.expires_in = DateTime.Now;
                response.user = "test.0000";
                response.userid = "test";
            }
            else
            {
                response.error = "Username or Password was not recognized.  Please try again.";
            }

            return response;
        }

        public NestAPIForecastResponse getForecast(NestAPICredentialsResponse credentials, string zip)
        {

            string json = "{\"display_city\":\"XXXXXX, XX\", \"city\":\"XXXXX\", \"forecast\":{ \"hourly\":[{ \"time\":1416106800, \"temp\":24, \"humidity\":79 },{ \"time\":1416110400, \"temp\":22, \"humidity\":79 },{ \"time\":1416114000, \"temp\":19, \"humidity\":78 },{ \"time\":1416117600, \"temp\":18, \"humidity\":77 },{ \"time\":1416121200, \"temp\":16, \"humidity\":74 },{ \"time\":1416124800, \"temp\":15, \"humidity\":72 },{ \"time\":1416128400, \"temp\":14, \"humidity\":70 },{ \"time\":1416132000, \"temp\":13, \"humidity\":69 },{ \"time\":1416135600, \"temp\":12, \"humidity\":70 },{ \"time\":1416139200, \"temp\":11, \"humidity\":71 },{ \"time\":1416142800, \"temp\":10, \"humidity\":71 },{ \"time\":1416146400, \"temp\":12, \"humidity\":66 },{ \"time\":1416150000, \"temp\":13, \"humidity\":71 },{ \"time\":1416153600, \"temp\":15, \"humidity\":64 },{ \"time\":1416157200, \"temp\":19, \"humidity\":56 },{ \"time\":1416160800, \"temp\":21, \"humidity\":52 },{ \"time\":1416164400, \"temp\":23, \"humidity\":51 },{ \"time\":1416168000, \"temp\":25, \"humidity\":46 },{ \"time\":1416171600, \"temp\":27, \"humidity\":42 },{ \"time\":1416175200, \"temp\":27, \"humidity\":43 },{ \"time\":1416178800, \"temp\":24, \"humidity\":47 },{ \"time\":1416182400, \"temp\":24, \"humidity\":51 },{ \"time\":1416186000, \"temp\":24, \"humidity\":55 },{ \"time\":1416189600, \"temp\":23, \"humidity\":64 },{ \"time\":1416193200, \"temp\":22, \"humidity\":70 },{ \"time\":1416196800, \"temp\":20, \"humidity\":68 },{ \"time\":1416200400, \"temp\":18, \"humidity\":68 },{ \"time\":1416204000, \"temp\":17, \"humidity\":68 },{ \"time\":1416207600, \"temp\":16, \"humidity\":72 },{ \"time\":1416211200, \"temp\":16, \"humidity\":72 },{ \"time\":1416214800, \"temp\":15, \"humidity\":70 },{ \"time\":1416218400, \"temp\":14, \"humidity\":70 },{ \"time\":1416222000, \"temp\":14, \"humidity\":72 },{ \"time\":1416225600, \"temp\":12, \"humidity\":72 },{ \"time\":1416229200, \"temp\":12, \"humidity\":74 },{ \"time\":1416232800, \"temp\":13, \"humidity\":67 },{ \"time\":1416236400, \"temp\":13, \"humidity\":70 },{ \"time\":1416240000, \"temp\":14, \"humidity\":69 },{ \"time\":1416243600, \"temp\":16, \"humidity\":62 },{ \"time\":1416247200, \"temp\":17, \"humidity\":58 },{ \"time\":1416250800, \"temp\":18, \"humidity\":54 },{ \"time\":1416254400, \"temp\":18, \"humidity\":52 },{ \"time\":1416258000, \"temp\":18, \"humidity\":52 },{ \"time\":1416261600, \"temp\":17, \"humidity\":52 },{ \"time\":1416265200, \"temp\":16, \"humidity\":56 },{ \"time\":1416268800, \"temp\":14, \"humidity\":57 },{ \"time\":1416272400, \"temp\":13, \"humidity\":58 },{ \"time\":1416276000, \"temp\":13, \"humidity\":60 }], \"daily\":[{ \"conditions\":\"Partly Cloudy\", \"date\":1416186000, \"high_temperature\":29, \"icon\":\"partlycloudy\", \"low_temperature\":11 },{ \"conditions\":\"Partly Cloudy\", \"date\":1416272400, \"high_temperature\":18, \"icon\":\"partlycloudy\", \"low_temperature\":8 },{ \"conditions\":\"Clear\", \"date\":1416358800, \"high_temperature\":33, \"icon\":\"clear\", \"low_temperature\":26 },{ \"conditions\":\"Clear\", \"date\":1416445200, \"high_temperature\":31, \"icon\":\"clear\", \"low_temperature\":18 },{ \"conditions\":\"Mostly Cloudy\", \"date\":1416531600, \"high_temperature\":36, \"icon\":\"mostlycloudy\", \"low_temperature\":15 },{ \"conditions\":\"Clear\", \"date\":1416618000, \"high_temperature\":33, \"icon\":\"clear\", \"low_temperature\":24 }] }, \"now\":{ \"station_id\":\"XXXXXXXXXX\", \"conditions\":\"Overcast\", \"current_humidity\":86, \"current_temperature\":-3.4, \"current_wind\":1.6, \"gmt_offset\":\"-6.00\", \"icon\":\"cloudy\", \"sunrise\":1416057218, \"sunset\":1416092888, \"wind_direction\":\"West\"}}";

            return JsonConvert.DeserializeObject<NestAPIForecastResponse>(json);
        }

        public NestAPIStatusResponse getNestStatus(NestAPICredentialsResponse credentials)
        {
            NestAPIStatusResponse response = new NestAPIStatusResponse();
            response.CurrentHumidity = "40";
            response.HasHumidifier = true;
            response.PostalCode = "XXXXX";
            response.SerialNumber = "XXXXXXXXX";
            response.StructureGUID = "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX";
            response.TargetHumidity = 40;
            return response;
        }

        public NestAPISetTargetHumidityResponse setTargetHumidity(NestAPICredentialsResponse credentials, NestAPIStatusResponse status, int newTargetHumidity)
        {
            NestAPISetTargetHumidityResponse response = new NestAPISetTargetHumidityResponse();
            response.ResponseResult = NestAPISetTargetHumidityResponse.ResponseResultOptions.SUCCESS;
            return response;
        }
    }
}

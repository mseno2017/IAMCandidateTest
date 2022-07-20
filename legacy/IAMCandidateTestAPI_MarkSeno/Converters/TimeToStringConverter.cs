using AutoMapper;
using System;

namespace IAMCandidateTestAPI_MarkSeno
{
    public class TimeToStringConverter : ITypeConverter<TimeSpan, string>
    {
        public string Convert(TimeSpan source, string destination, ResolutionContext context)
        {
            return source.ToString(@"hh\:mm"); ;
        }
    }
}

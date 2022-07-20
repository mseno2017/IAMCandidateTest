using AutoMapper;
using System;

namespace IAMCandidateTestAPI_MarkSeno
{
    public class StringToTimeConverter: ITypeConverter<string, TimeSpan>
    {
        public TimeSpan Convert(string source, TimeSpan destination, ResolutionContext context)
        {
            return TimeSpan.Parse(source);
        }
    }
}

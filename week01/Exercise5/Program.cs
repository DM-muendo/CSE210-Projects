/*
The Use of Computers in Mapping: The Democratization of Cartography

Introduction:
The integration of computers into mapping has fundamentally transformed cartography, making it accessible to a broader audience. Traditionally, map-making was a specialized skill reserved for experts with access to expensive tools and data. Today, digital technologies have lowered these barriers, allowing individuals, communities, and organizations to participate in the creation and use of maps. This democratization has not only increased the volume and diversity of maps but also enhanced their relevance and utility in everyday life. The following points discuss how computers have contributed to this shift.

1. Accessibility:
Computers and the internet have made mapping tools available to anyone with a device and connectivity. Free and user-friendly platforms such as Google Maps and OpenStreetMap allow users to create, edit, and share maps without specialized training. This accessibility empowers people to visualize their surroundings and plan activities more effectively. It also enables marginalized groups to represent their own spaces and issues. As a result, mapping is no longer limited to professionals but is a tool for all.

2. Open Data:
The rise of open data initiatives has been facilitated by computers, enabling the sharing of geographic information freely. Projects like OpenStreetMap rely on contributions from volunteers worldwide, creating a rich and constantly updated database. Open data reduces dependency on proprietary sources and encourages transparency. It allows researchers, developers, and the public to access and use spatial data for various purposes. This collaborative approach has expanded the scope and accuracy of cartographic information.

3. User-generated Content:
Digital mapping platforms encourage users to contribute their own data, such as points of interest, routes, and local knowledge. This crowdsourcing model increases the granularity and relevance of maps, especially in areas overlooked by traditional cartographers. User-generated content can quickly reflect changes in the environment, such as new roads or buildings. It also fosters community engagement and ownership of spatial information. The collective input leads to more comprehensive and dynamic maps.

4. Cost Reduction:
Computers have significantly lowered the costs associated with cartography. Expensive equipment, printing, and specialized software are no longer prerequisites for map-making. Free or low-cost digital tools and cloud services allow anyone to produce and distribute maps. This reduction in cost democratizes access, enabling small organizations and individuals to participate. It also encourages innovation by removing financial barriers.

5. Customization:
Digital mapping tools allow users to tailor maps to their specific needs and interests. Custom layers, filters, and annotations can be added to highlight relevant information, such as disaster zones or community resources. This flexibility supports diverse applications, from urban planning to environmental monitoring. Customization ensures that maps are more useful and meaningful to their intended audiences. It also promotes creativity in how spatial data is presented and interpreted.

6. Real-time Updates:
Computers enable maps to be updated in real time, reflecting current events and changes in the environment. GPS and sensor data can be integrated to show live traffic, weather, or emergency situations. Real-time mapping is crucial for disaster response, navigation, and public safety. It allows users to make informed decisions based on the latest information. This immediacy was not possible with traditional, static maps.

7. Integration with Other Technologies:
Digital maps can be combined with GPS, mobile applications, and social media for enhanced functionality. Location-based services rely on this integration to provide personalized recommendations and navigation. Social media platforms use mapping to visualize trends and connect users. The synergy between mapping and other technologies expands the possibilities for spatial analysis and communication. It also makes maps more interactive and engaging.

8. Visualization Tools:
Geographic Information Systems (GIS) and other visualization software allow non-experts to analyze and display complex spatial data. These tools provide intuitive interfaces for creating charts, heatmaps, and 3D models. Visualization enhances understanding of patterns and relationships in data. It supports decision-making in fields such as health, business, and environmental science. The democratization of visualization tools means more people can participate in spatial analysis.

9. Global Collaboration:
Computers facilitate global collaboration in mapping projects, connecting contributors from different regions and backgrounds. Online platforms enable coordinated efforts to map disaster zones, humanitarian needs, or environmental changes. Collaboration increases the quality and coverage of maps, especially in underserved areas. It also fosters cross-cultural exchange and learning. The global nature of digital cartography strengthens its impact and relevance.

10. Educational Opportunities:
Digital cartography is increasingly integrated into educational curricula, promoting spatial literacy among students. Interactive mapping tools make learning about geography and spatial relationships engaging and practical. Students can create their own maps, conduct research, and share findings. Education in cartography empowers future generations to use spatial data effectively. It also ensures that mapping skills are distributed widely across society.

References:
1. Goodchild, M. F. (2007). "Citizens as sensors: The world of volunteered geography." GeoJournal, 69(4), 211-221.
2. Haklay, M. (2010). "How good is volunteered geographical information? The case of OpenStreetMap." Computers, Environment and Urban Systems, 34(3), 183-198.
3. Sui, D., Elwood, S., & Goodchild, M. (2011). "Crowdsourcing geographic knowledge: Volunteered geographic information (VGI) in theory and practice." Springer.
4. Dodge, M., Kitchin, R., & Perkins, C. (2011). "The Map as a Tool of Science." In The Map Reader. Wiley.
5. Graham, M., & Zook, M. (2013). "Augmented realities and urban life: The geography of mobile computing and locative media." Annals of the Association of American Geographers, 103(2), 451-463.
6. Sieber, R. (2006). "Public participation geographic information systems: A literature review and framework." Annals of the Association of American Geographers, 96(3), 491-507.
7. Crampton, J. W. (2009). "Cartography: Maps 2.0." Progress in Human Geography, 33(1), 94-100.
8. Batty, M. (2013). "Big data, smart cities and city planning." Dialogues in Human Geography, 3(3), 274-279.

Conclusion:
The use of computers in mapping has democratized cartography, making it a participatory and dynamic field. By lowering barriers and enabling collaboration, digital technologies have expanded the reach and impact of maps. This transformation supports innovation, inclusivity, and responsiveness in spatial analysis. As technology continues to advance, the role of cartography in society will grow, empowering more people to engage with and shape their environments. The democratization of cartography is a testament to the power of computers in fostering knowledge and connectivity.
*/
using System;

class Program
{
    static void Main(string[] args)
    {
        DisplayWelcome();
        string name = PromptUserName();
        int number = PromptUserNumber();
        int squared = SquareNumber(number);
        DisplayResult(name, squared);
    }

    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the Program!");
    }

    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        return Console.ReadLine();
    }

    static int PromptUserNumber()
    {
        Console.Write("Please enter your favorite number: ");
        return int.Parse(Console.ReadLine());
    }

    static int SquareNumber(int number)
    {
        return number * number;
    }

    static void DisplayResult(string name, int squared)
    {
        Console.WriteLine($"{name}, the square of your number is {squared}");
        
        // Fancy moment based on squared number
        string[] emotions = { "joy", "peace", "worry", "sad", "torment", "fantasy" };
        int index = squared % 6;
        Console.WriteLine($"A fancy moment of {emotions[index]}!");
    }
}
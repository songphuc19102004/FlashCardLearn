using FlashCardLearn.ViewModel;
using Repositories.Models;
using Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FlashCardLearn.Views
{
    /// <summary>
    /// Interaction logic for FlashCardManagerView.xaml
    /// </summary>
    public partial class FlashCardManagerView : Window
    {
        #region const
        private const string content = "(WEEK 1)\r\nQuestion 1\r\nIs ethics a checklist?\r\n\r\nA. True\r\nB. False\tB. False\r\nQuestion 2\r\nWhat is moral responsibility?\r\n\r\nA. It corresponds to liability\r\nB. It means to be accountable for our actions and the effects of these actions\r\nC. It means to adopt a moral theory describing responsibility\r\nD. It is an ethical approach in professional life\tB. It means to be accountable for our actions and the effects of these actions\r\nQuestion 3\r\nMoral responsibility is based on: (Select multiple answers)\r\n\r\nA. ethical theories\r\nB. obligations and norms arising from moral considerations\r\nC. personal presuppositions\r\nD. moral duties\tB. obligations and norms arising from moral considerations\r\n\r\nD. moral duties\r\nQuestion 4\r\nIs Passive Responsibility a form of backward-looking responsibility?\r\n\r\nA. True\r\nB. False\tA. True\r\nQuestion 5\r\nWhich are the elements that play a key role in assessing responsibility? (Select multiple answers)\r\n\r\nA. Accountability\r\nB. Morality\r\nC. Ethics\r\nD. Blameworthiness\tA. Accountability\r\n\r\nD. Blameworthiness\r\nQuestion 6\r\nWhat is foreseeability?\r\n\r\nA. The ability to predict the future\r\nB. To describe responsible action\r\nC. To have freedom of action\r\nD.To be able to know the consequences of action\tD. To be able to know the consequences of action\r\nQuestion 7\r\nActive responsibility means... (Select multiple answers) \r\n\r\nA. to attribute responsibility in a backward-looking way\r\nB. to prevent the negative effects of technology\r\nC. to causally contributing to the development of a technology\r\nD. to realize some positive consequences of technology\tB. to prevent the negative effects of technology\r\n\r\nD. to realize some positive consequences of technology\r\nQuestion 8\r\nIs Value Sensitive Design a form of active responsibility?\r\n\r\nA. True\r\nB. False\tA. True\r\n(WEEK 2) \r\n\r\nQuestion 1\r\nWhat is utilitarianism? (Select muliple answers).\r\n\r\nA. A type of consequentialism, where decisions and actions are evaluated as morally good or bad according to the consequences they bring about\r\nB. An ethical framework based on the utility principle\r\nC. A form of ethics based on duties\r\nD. A moral approach explaining the principle of utility\tA. A type of consequentialism, where decisions and actions are evaluated as morally good or bad according to the consequences they bring about\r\n\r\nB. An ethical framework based on the utility principle\r\nQuestion 2\r\nIs duty ethics a framework in which an action is considered morally right if it agrees with a certain moral rule?\r\n\r\nA. True\r\nB. False\tA. True\r\nQuestion 3\r\nWhat does it mean that a weapon system is autonomous?\r\n\r\nA. It means that it has moral capabilities\r\nB. It means that it is not independent from human supervision\r\nC. It means that it has navigation, exploration and attack capabilities and does not require continuous human supervision\r\nD. It means designing autonomous weapons to avoid negative consequences\tC. It means that it has navigation, exploration and attack capabilities and does not require continuous human supervision\r\nQuestion 4\r\nWhat is meaningful human control? (Select multiple answers)\r\n\r\nA. The type of control for which the human controller must have enough information and time to intervene on the autonomous systems\r\nB. A concept proposed in the last years as a necessary condition for the responsible employment of autonomous weapon systems\r\nC. A way to describe how autonomous systems work\tA. The type of control for which the human controller must have enough information and time to intervene on the autonomous systems\r\n\r\nB. A concept proposed in the last years as a necessary condition for the responsible employment of autonomous weapon systems\r\nQuestion 5\r\nDigital health and digital medicine have mainly four areas of application\r\n\r\nA. True\r\nB. False\tA. True\r\nQuestion 6\r\nTo establish the sustainability of digital services, it is important...\r\n\r\nA. to measure all the consequences deriving from digital services\r\nB. to evaluate the involved stakeholders\r\nC. to consider both the numerical value of their environmental impact and their social value\tC. to consider both the numerical value of their environmental impact and their social value\r\nQuestion 7\r\nWhat is the goal of cybersecurity?\r\n\r\nA. To promote security breaches\r\nB. To guarantee the confidentiality, integrity, and availability of information\r\nC. To avoid the confidentiality of information\r\nD. To combat hackers\tB. To guarantee the confidentiality, integrity, and availability of information\r\n(WEEK 3)\r\n\r\nQuestion 1\r\nAutomated Decision Systems (Select multiple answers)\r\n\r\nA. use today a traditional top-down approach\r\nB. have the ability to learn from experience\r\nC. process data about people and combine human and automated decision making\tB. have the ability to learn from experience\r\n\r\nC. process data about people and combine human and automated decision making\r\nQuestion 2\r\nIs classification a possible form of learning?\r\n\r\nA. True\r\nB. False\tA. True\r\nQuestion 3\r\nTo say that Automated Decision Systems are black boxes means that: (Select multiple answers)\r\n\r\nA. their decisions can be explained\r\nB. they are designed according to the Explainable AI approach\r\nC. they are not transparent\r\nD. they hide their internal logic to the user\tC. they are not transparent\r\n\r\nD. they hide their internal logic to the user\r\nQuestion 4\r\nAn algorithm is biased when:\r\n\r\nA. it is trained on a set of data containing biases\r\nB. it is designed to solve racial prejudices\r\nC. it lacks appropriate biases\tA. it is trained on a set of data containing biases\r\nQuestion 5\r\nIs Privacy related to the right to be left alone?\r\n\r\nA. True\r\nB. False\tA. True\r\nQuestion 6\r\nPrivacy... (Select multiple answers)\r\n\r\nA. ...only protects people who have something to hide\r\nB. ...is not overrated\r\nC. ...is about intensive tracking and monitoring of behaviors\r\nD. ...is totally lost today\tB. ...is not overrated\r\n\r\nC. ...is about intensive tracking and monitoring of behaviors\r\nQuestion 7\r\nPrivacy does not play an essential role for the diversity of relationships.\r\n\r\nA. False\r\nB. True\tA. False\r\nQuestion 8\r\nWhat is a panopticon?\r\n\r\nA. A digital tool to spy people\r\nB. A way of considering privacy as essential only to those who have something to hide\r\nC. A structure designed to serve as a prison\r\nD. A metaphor to describe the freedom of individuals\tC. A structure designed to serve as a prison\r\nQuestion 9\r\nThe moralization of technologies is: (Select multiple answers)\r\n\r\nA. the deliberate development of technologies in order to shape moral action and moral decision-making\r\nB. the design of moral intelligent agents\r\nC. the attempt to moralize the material environment in which people operate\r\nD. the field of ethics devoted to the study of the consequences of technologies\tA. the deliberate development of technologies in order to shape moral action and moral decision-making\r\n\r\nC. the attempt to moralize the material environment in which people operate\r\nQuestion 10\r\nWhat are experimental technologies?\r\n\r\nA. technologies that need collaborative experimentation to be tested\r\nB. technologies with a limited operational experience\r\nC. technologies involving the experimentation on human subjects\r\nD. technologies requiring the involvement of experimentalists to be designed\tB. technologies with a limited operational experience\r\n(WEEK 4)\r\n\r\nQuestion 1\r\nAre codes of ethics and conduct related to professional ethics?\r\n\r\nA. True\r\nB. False\tA. True\r\nQuestion 2\r\nProfessional codes... (Select multiple answers)\r\n\r\nA. ...describe computing professionals\r\nB. ...are formulated for a variety of reasons\r\nC. ...express the values of integrity, honesty, and avoid of conflict of interest\r\nD. ...try to use mathematical formulas to express the responsibilities of professionals\tB. ...are formulated for a variety of reasons\r\n\r\nC. ...express the values of integrity, honesty, and avoid of conflict of interest\r\nQuestion 3\r\nWhat is a socio-technical perspective in the ethics of AI?\r\n\r\nA. it is a technical approach to the solution of ethical issues\r\nB. it concerns the fact that ethical issues of AI can be solved both by humans and machines\r\nC. it means integrating technical solutions into broader ethical and social frameworks\tC. it means integrating technical solutions into broader ethical and social frameworks\r\nQuestion 4\r\nEthics of AI... (Select multiple answers)\r\n\r\nA. ...requires a paradigm change\r\nB. ...involves different stakeholders\r\nC. ...has the goal of implementing machines with an ethics\r\nD. ...considers AI tools and techniques as dangerous\tA. ...requires a paradigm change\r\n\r\nB. ...involves different stakeholders";
        #endregion
        #region const
        private const string content2 = "Which of the following defines the AI black box problem?\r\nA. A dangerous machine intelligence put in a digital prison\r\nB. Machine intelligence making something illusory, like pulling a rabbit from a hat\r\nC. The challenge of understanding the inner workings of opaque systems\r\nD. Not being able to know how something crashed or failed\tC\r\nWhich of the following elements are important aspects of ethical integrity with regards to data? (Select two.)\r\nA. If the holders of data are trustworthy entities.\r\nB. If the data is commercially viable or monetarily valuable.\r\nC. Whether the data was gathered in an ethical manner.\r\nD. What type of data (audio, visual, etc.) is being collected and/or utilized.\tA C\r\nWhich of the following best describes why data is sometimes compared to oil? (Select two.)\r\nA. Data can be monetarily valuable.\r\nB. Data can damage the environment.\r\nC. Data can be easily monopolized.\r\nD. Data can fuel algorithmic technologies.\tA D\r\nAt what point should ethical consideration ideally be applied to emerging technologies?\r\nA. Upon delivery, with appropriate warranties where necessary.\r\nB. During periodic reviews, with ongoing customer feedback solicited.\r\nC. From its inception, through maintenance, to applying foresight regarding its decommissioning.\r\nD. Once an ethical issue has received negative feedback in public media.\tC\r\nWhich of the following describes dual-use or multipurpose data?\r\nA. Data that can be easily shared with a partner or family member for mutual enjoyment.\r\nB. Data that can be used in multiple devices or formats, such as a video on a Smart TV, tablet, and computer.\r\nC. Data collected for one application that could also be applied to another application in a different domain.\r\nD. Data that can be transformed into multiple forms, e.g. extracting audio from a video file.\tC\r\nWhich of the following are important ethical elements to safeguard within ethical AI systems? (Select two.)\r\nA. Accountability and management of bias.\r\nB. Transparency and explainability, balanced with privacy.\r\nC. The number of layers, tensors, or parameters used in a model.\r\nD. Performance and optimization.\tA B\r\nWhich of the following is the generally agreed upon current state of the art of AI?\r\nA. Superintelligence\r\nB. Narrow AI\r\nC. Strong AI\r\nD. Perceptrons\tB\r\nWhich of the following describe important aspects of why emerging technologies are so capable and powerful? (Select two.)\r\nA. They can automate very complex operations.\r\nB. They may be able to self-improve by learning from data.\r\nC. They are exciting and captivating to many people.\r\nD. They can displace workers by performing their jobs more efficiently.\tA B\r\nManagement asks someone to do a data-related task. Which of the following would likely be ethically problematic? (Select two.)\r\nA. Aggregate data together.\r\nB. Change data to another format.\r\nC. Manipulate data or alter its interpretation.\r\nD. Delete any erroneous data.\tC D\r\nWhich of the following describe important aspects in the role of an ethical AI engineer? (Select two.)\r\nA. Building and maintaining computational hardware.\r\nB. Writing new equations to express intelligence.\r\nC. Keeping up with the latest developments and vulnerabilities.\r\nD. Cleaning and sorting data, and auditing for bias.\tC D\r\nWhich of the following, by itself, qualifies as personally identifiable information (PII)?\r\nA. Temperature readings for an office building\r\nB. A user's customer ID in an online ordering system\r\nC. System events added to a log\r\nD. A user's home address\tD\r\nWhy are groups like race and religion considered protected classes?\r\nA. These groups have been used as the basis for wholesale discrimination.\r\nB. These groups can be used to personally identify someone.\r\nC. People use these groups as the basis for their identities.\r\nD. Organizations are legally not allowed to collect information about these groups.\tA\r\nWhich of the following describes an opt-out policy in regards to the collection of private data?\r\nA. Data about the user is always collected, regardless of the user's consent.\r\nB. Data about that user isn't collected until that user explicitly states you are allowed to.\r\nC. Data about the user is never collected, regardless of the user's consent.\r\nD. Data about the user is automatically collected unless that user explicitly states that you should not do so.\tD\r\nWhich of the following are key principles of privacy by design? (Select two.)\r\nA. Organizations must incorporate privacy protections throughout the project lifecycle.\r\nB. Organizations must keep the focus of privacy protections on the business rather than the user.\r\nC. Organizations must not expose the operational practices and technologies used to protect user privacy.\r\nD. Organizations must be proactive in protecting against privacy risks, not reactive.\tA D\r\nWhat is the purpose of differential privacy?\r\nA. To only allow certain parties to access certain portions of the data.\r\nB. To enable parties to share private data without revealing individuals represented in the data.\r\nC. To remove the direct identifiers that can be used to identify individuals.\r\nD. To ensure the data is completely confidential and cannot be read by unauthorized parties.\tB\r\nWhich of the following describes the concept of liability?\r\nA. Answering for one's actions to an authority figure.\r\nB. Taking ownership of an assigned task.\r\nC. The legal responsibility for one's actions.\r\nD. The moral duty one has to take action.\tC\r\nWhat does it mean to call a click-through agreement a \"contract of adhesion\"?\r\nA. Both parties are equally responsible for ensuring the agreement is adhered to.\r\nB. One party is forced into a \"take-it-or-leave-it\" situation.\r\nC. One party is forced into using the service after agreeing.\r\nD. Both parties are legally bound by the agreement.\tB\r\nWhich of the following is a type of technology contract that establishes the goals of both parties and describes how those goals will be achieved?\r\nA. Software as a Service (SaaS)\r\nB. Service-level agreement (SLA)\r\nC. Terms of Service (ToS)\r\nD. End-user license agreement (EULA)\tB";
        #endregion
        #region const
        private const string content3 = "No\tasd\r\n1 1\tques ans\r\n2 2\tques ans\r\nques ans\tques ans\r\nques ans\tques ans\r\nques ans\tques ans\r\nques ans\tques ans\r\nques ans\tques ans\r\nques ans\tques ans\r\nques ans\tques ans\r\nques ans\tques ans\r\nques ans\tques ans\r\nques ans\tques ans\r\nques ans\tques ans\r\nques ans\tques ans\r\nques ans\tques ans";
        #endregion
        public FlashCardManagerView()
        {
            InitializeComponent();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void InfoButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("You can add/edit/delete flash card by using the grid below", "Guide", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            List<FlashCard> flashCards = new List<FlashCard>()
            {
                new FlashCard
                {
                    Answer = "1",
                    Question = "1",
                    FlashcardsetId = 99,
                    Id= 1,
                },
                new FlashCard
                {
                    Answer = "2",
                    Question = "2",
                    FlashcardsetId = 99,
                    Id= 2,
                },
                new FlashCard
                {
                    Answer = "3",
                    Question = "3",
                    FlashcardsetId = 99,
                    Id= 3,
                },
                new FlashCard
                {
                    Answer = "4",
                    Question = "4",
                    FlashcardsetId = 99,
                    Id= 4,
                },
                new FlashCard
                {
                    Answer = "5",
                    Question = "5",
                    FlashcardsetId = 99,
                    Id= 5,
                },
                new FlashCard
                {
                    Answer = "6",
                    Question = "6",
                    FlashcardsetId = 99,
                    Id= 6,
                }
            };
            ImportExportHelper.ExportFlashcardListToFile(flashCards);
        }
    }
}

namespace Scsi
{
    public static class VendorIdentifiers
    {
        public static string GetVendorName(string vendorId)
        {
            vendorId = vendorId.Trim();
            switch (vendorId)
            {
                case "0B4C":
                    return "MOOSIK Ltd.";
                case "2AI":
                    return "2AI (Automatisme et Avenir Informatique)";
                case "3M":
                    return "3M Company";
                case "3nhtech":
                    return "3NH Technologies";
                case "3PARdata":
                    return "3PARdata, Inc.";
                case "A-Max":
                    return "A-Max Technology Co., Ltd";
                case "ABSOLUTE":
                    return "Absolute Analysis";
                case "ACARD":
                    return "ACARD Technology Corp.";
                case "Accusys":
                    return "Accusys INC.";
                case "Acer":
                    return "Acer, Inc.";
                case "ACL":
                    return "Automated Cartridge Librarys, Inc.";
                case "Acuid":
                    return "Acuid Corporation Ltd.";
                case "AcuLab":
                    return "AcuLab, Inc. (Tulsa, OK)";
                case "ADAPTEC":
                    return "Adaptec";
                case "ADIC":
                    return "Advanced Digital Information Corporation";
                case "ADSI":
                    return "Adaptive Data Systems, Inc. (a Western Digital subsidiary)";
                case "ADTX":
                    return "ADTX Co., Ltd.";
                case "ADVA":
                    return "ADVA Optical Networking AG";
                case "AERONICS":
                    return "Aeronics, Inc.";
                case "AGFA":
                    return "AGFA";
                case "AIC":
                    return "Advanced Industrial Computer, Inc.";
                case "AIPTEK":
                    return "AIPTEK International Inc.";
                case "AMCC":
                    return "Applied Micro Circuits Corporation";
                case "AMCODYNE":
                    return "Amcodyne";
                case "Amgeon":
                    return "Amgeon LLC";
                case "AMI":
                    return "American Megatrends, Inc.";
                case "Amphenol":
                    return "Amphenol";
                case "Amtl":
                    return "Tenlon Technology Co.,Ltd";
                case "ANAMATIC":
                    return "Anamartic Limited (England)";
                case "Ancor":
                    return "Ancor Communications, Inc.";
                case "ANCOT":
                    return "ANCOT Corp.";
                case "ANDATACO":
                    return "Andataco  (now nStor)";
                case "andiamo":
                    return "Andiamo Systems, Inc.";
                case "ANRITSU":
                    return "Anritsu Corporation";
                case "ANTONIO":
                    return "Antonio Precise Products Manufactory Ltd.";
                case "AoT":
                    return "Art of Technology AG";
                case "APPLE":
                    return "Apple Computer, Inc.";
                case "ARCHIVE":
                    return "Archive";
                case "ARDENCE":
                    return "Ardence Inc";
                case "Areca":
                    return "Areca Technology Corporation";
                case "ARIO":
                    return "Ario Data Networks, Inc.";
                case "ARISTOS":
                    return "Aristos Logic Corp. (now part of Adaptec)";
                case "ARK":
                    return "ARK Research Corporation";
                case "ARTECON":
                    return "Artecon Inc.  (Obs. - now Dot Hill)";
                case "ASACA":
                    return "ASACA Corp.";
                case "ASC":
                    return "Advanced Storage Concepts, Inc.";
                case "ASPEN":
                    return "Aspen Peripherals";
                case "AST":
                    return "AST Research";
                case "ASTK":
                    return "Alcatel STK A/S";
                case "ASTUTE":
                    return "Astute Networks, Inc.";
                case "AT&T":
                    return "AT&T";
                case "ATA":
                    return "SCSI / ATA Translator Software (Organization Not Specified)";
                case "ATARI":
                    return "Atari Corporation";
                case "ATG CYG":
                    return "ATG Cygnet Inc.";
                case "ATL":
                    return "Quantum|ATL Products";
                case "ATTO":
                    return "ATTO Technology Inc.";
                case "ATX":
                    return "Alphatronix";
                case "AURASEN":
                    return "Aurasen Limited";
                case "AVC":
                    return "AVC Technology Ltd";
                case "AVR":
                    return "Advanced Vision Research";
                case "AXSTOR":
                    return "AXSTOR";
                case "BALLARD":
                    return "Ballard Synergy Corp.";
                case "Barco":
                    return "Barco";
                case "BAROMTEC":
                    return "Barom Technologies Co., Ltd.";
                case "Bassett":
                    return "Bassett Electronic Systems Ltd";
                case "BDT":
                    return "BDT AG";
                case "BECEEM":
                    return "Beceem Communications, Inc";
                case "BENQ":
                    return "BENQ Corporation.";
                case "BERGSWD":
                    return "Berg Software Design";
                case "BEZIER":
                    return "Bezier Systems, Inc.";
                case "BHTi":
                    return "Breece Hill Technologies";
                case "BIOS":
                    return "BIOS Corporation";
                case "BIR":
                    return "Bio-Imaging Research, Inc.";
                case "BiT":
                    return "BiT Microsystems (obsolete, new ID: BITMICRO)";
                case "BITMICRO":
                    return "BiT Microsystems, Inc.";
                case "BLOOMBAS":
                    return "Bloombase Technologies Limited";
                case "BlueArc":
                    return "BlueArc Corporation";
                case "BNCHMARK":
                    return "Benchmark Tape Systems Corporation";
                case "Bosch":
                    return "Robert Bosch GmbH";
                case "BoxHill":
                    return "Box Hill Systems Corporation  (Obs. - now Dot Hill)";
                case "BRDGWRKS":
                    return "Bridgeworks Ltd.";
                case "BREA":
                    return "BREA Technologies, Inc.";
                case "BREECE":
                    return "Breece Hill LLC";
                case "Broadcom":
                    return "Broadcom Corporation";
                case "BROCADE":
                    return "Brocade Communications Systems, Incorporated";
                case "BUFFALO":
                    return "BUFFALO INC.";
                case "BULL":
                    return "Bull Peripherals Corp.";
                case "BUSLOGIC":
                    return "BusLogic Inc.";
                case "BVIRTUAL":
                    return "B-Virtual N.V.";
                case "CalComp":
                    return "CalComp, A Lockheed Company";
                case "CALCULEX":
                    return "CALCULEX, Inc.";
                case "CALIPER":
                    return "Caliper (California Peripheral Corp.)";
                case "CAMBEX":
                    return "Cambex Corporation";
                case "CAMEOSYS":
                    return "Cameo Systems Inc.";
                case "CANDERA":
                    return "Candera Inc.";
                case "CAPTION":
                    return "CAPTION BANK";
                case "CAST":
                    return "Advanced Storage Tech";
                case "CATALYST":
                    return "Catalyst Enterprises";
                case "CCDISK":
                    return "iSCSI Cake";
                case "CDC":
                    return "Control Data or MPI";
                case "CDP":
                    return "Columbia Data Products";
                case "Celsia":
                    return "A M Bromley Limited";
                case "CenData":
                    return "Central Data Corporation";
                case "Cereva":
                    return "Cereva Networks Inc.";
                case "CERTANCE":
                    return "Certance";
                case "CHEROKEE":
                    return "Cherokee Data Systems";
                case "CHINON":
                    return "Chinon";
                case "CIE&YED":
                    return "YE Data, C.Itoh Electric Corp.";
                case "CIPHER":
                    return "Cipher Data Products";
                case "Ciprico":
                    return "Ciprico, Inc.";
                case "CIRRUSL":
                    return "Cirrus Logic Inc.";
                case "CISCO":
                    return "Cisco Systems, Inc.";
                case "CLOVERLF":
                    return "Cloverleaf Communications, Inc";
                case "CLS":
                    return "Celestica";
                case "CMD":
                    return "CMD Technology Inc.";
                case "CMTechno":
                    return "CMTech";
                case "CNGR SFW":
                    return "Congruent Software, Inc.";
                case "CNSi":
                    return "Chaparral Network Storage, Inc.";
                case "CNT":
                    return "Computer Network Technology";
                case "COBY":
                    return "Coby Electronics Corporation, USA";
                case "COGITO":
                    return "Cogito";
                case "COMPAQ":
                    return "Compaq Computer Corporation (now HP)";
                case "COMPELNT":
                    return "Compellent Technologies, Inc.";
                case "COMPORT":
                    return "Comport Corp.";
                case "COMPSIG":
                    return "Computer Signal Corporation";
                case "COMPTEX":
                    return "Comptex Pty Limited";
                case "CONNER":
                    return "Conner Peripherals";
                case "COPANSYS":
                    return "COPAN SYSTEMS INC";
                case "CORAID":
                    return "Coraid, Inc";
                case "CORE":
                    return "Core International, Inc.";
                case "COVOTE":
                    return "Covote GmbH & Co KG";
                case "COWON":
                    return "COWON SYSTEMS, Inc.";
                case "CPL":
                    return "Cross Products Ltd";
                case "CPU TECH":
                    return "CPU Technology, Inc.";
                case "CREO":
                    return "Creo Products Inc.";
                case "CROSFLD":
                    return "Crosfield Electronics (now FujiFilm Electonic Imaging Ltd)";
                case "CROSSRDS":
                    return "Crossroads Systems, Inc.";
                case "crosswlk":
                    return "Crosswalk, Inc.";
                case "CSCOVRTS":
                    return "Cisco - Veritas";
                case "CSM, INC":
                    return "Computer SM, Inc.";
                case "Cunuqui":
                    return "CUNUQUI SLU";
                case "CYBERNET":
                    return "Cybernetics";
                case "Cygnal":
                    return "Dekimo";
                case "DALSEMI":
                    return "Dallas Semiconductor";
                case "DANEELEC":
                    return "Dane-Elec";
                case "DANGER":
                    return "Danger Inc.";
                case "DAT-MG":
                    return "DAT Manufacturers Group";
                case "Data Com":
                    return "Data Com Information Systems Pty. Ltd.";
                case "DATABOOK":
                    return "Databook, Inc.";
                case "DATACOPY":
                    return "Datacopy Corp.";
                case "DataCore":
                    return "DataCore Software Corporation";
                case "DATAPT":
                    return "Datapoint Corp.";
                case "DATARAM":
                    return "Dataram Corporation";
                case "DDN":
                    return "DataDirect Networks, Inc.";
                case "DDRDRIVE":
                    return "DDRdrive LLC";
                case "DEC":
                    return "Digital Equipment Corporation (now HP)";
                case "DEI":
                    return "Digital Engineering, Inc.";
                case "DELL":
                    return "Dell Computer Corporation";
                case "DELPHI":
                    return "Delphi Data Div. of Sparks Industries, Inc.";
                case "DENON":
                    return "Denon/Nippon Columbia";
                case "DenOptix":
                    return "DenOptix, Inc.";
                case "DEST":
                    return "DEST Corp.";
                case "DFC":
                    return "DavioFranke.com";
                case "DGC":
                    return "Data General Corp.";
                case "DIGIDATA":
                    return "Digi-Data Corporation";
                case "DigiIntl":
                    return "Digi International";
                case "Digital":
                    return "Digital Equipment Corporation (now HP)";
                case "DILOG":
                    return "Distributed Logic Corp.";
                case "DISC":
                    return "Document Imaging Systems Corp.";
                case "DLNET":
                    return "Driveline";
                case "DNS":
                    return "Data and Network Security";
                case "DotHill":
                    return "Dot Hill Systems Corp.";
                case "DP":
                    return "Dell, Inc.";
                case "DPT":
                    return "Distributed Processing Technology";
                case "DROBO":
                    return "Data Robotics, Inc.";
                case "DSC":
                    return "DigitalStream Corporation";
                case "DSI":
                    return "Data Spectrum, Inc.";
                case "DSM":
                    return "Deterner Steuerungs- und Maschinenbau GmbH & Co.";
                case "DSNET":
                    return "Cleversafe, Inc.";
                case "DT":
                    return "Double-Take Software, INC.";
                case "DTC QUME":
                    return "Data Technology Qume";
                case "DXIMAGIN":
                    return "DX Imaging";
                case "ECCS":
                    return "ECCS, Inc.";
                case "ECMA":
                    return "European Computer Manufacturers Association";
                case "elipsan":
                    return "Elipsan UK Ltd.";
                case "Elms":
                    return "Elms Systems Corporation";
                case "EMASS":
                    return "EMASS, Inc.";
                case "EMC":
                    return "EMC Corp.";
                case "EMTEC":
                    return "EMTEC Magnetics";
                case "EMULEX":
                    return "Emulex";
                case "ENERGY-B":
                    return "Energybeam Corporation";
                case "ENGENIO":
                    return "Engenio Information Technologies, Inc.";
                case "EPOS":
                    return "EPOS Technologies Ltd.";
                case "EPSON":
                    return "Epson";
                case "EQLOGIC":
                    return "EqualLogic";
                case "Eris/RSI":
                    return "RSI Systems, Inc.";
                case "EuroLogc":
                    return "Eurologic Systems Limited (now part of Adaptec)";
                case "evolve":
                    return "Evolution Technologies, Inc";
                case "EXABYTE":
                    return "Exabyte Corp.";
                case "EXATEL":
                    return "Exatelecom Co., Ltd.";
                case "EXAVIO":
                    return "Exavio, Inc.";
                case "Exsequi":
                    return "Exsequi Ltd";
                case "Exxotest":
                    return "Annecy Electronique";
                case "FALCON":
                    return "FalconStor, Inc.";
                case "FFEILTD":
                    return "FujiFilm Electonic Imaging Ltd";
                case "Fibxn":
                    return "Fiberxon, Inc.";
                case "FID":
                    return "First International Digital, Inc.";
                case "FILENET":
                    return "FileNet Corp.";
                case "FirmFact":
                    return "Firmware Factory Ltd";
                case "FOXCONN":
                    return "Foxconn Technology Group";
                case "FRAMDRV":
                    return "FRAMEDRIVE Corp.";
                case "FREECION":
                    return "Nable Communications, Inc.";
                case "FSC":
                    return "Fujitsu Siemens Computers";
                case "FTPL":
                    return "Frontline Technologies Pte Ltd";
                case "FUJI":
                    return "Fuji Electric Co., Ltd. (Japan)";
                case "FUJIFILM":
                    return "Fuji Photo Film, Co., Ltd.";
                case "FUJITSU":
                    return "Fujitsu";
                case "FUNAI":
                    return "Funai Electric Co., Ltd.";
                case "FUTURED":
                    return "Future Domain Corp.";
                case "G&D":
                    return "Giesecke & Devrient GmbH";
                case "Gadzoox":
                    return "Gadzoox Networks, Inc. (now part of Broadcom)";
                case "Gammaflx":
                    return "Gammaflux L.P.";
                case "GDI":
                    return "Generic Distribution International";
                case "Gen_Dyn":
                    return "General Dynamics";
                case "Generic":
                    return "Generic Technology Co., Ltd.";
                case "GENSIG":
                    return "General Signal Networks";
                case "GIGATAPE":
                    return "GIGATAPE GmbH";
                case "GIGATRND":
                    return "GigaTrend Incorporated";
                case "Global":
                    return "Global Memory Test Consortium";
                case "Gnutek":
                    return "Gnutek Ltd.";
                case "Goidelic":
                    return "Goidelic Precision, Inc.";
                case "GoldStar":
                    return "LG Electronics Inc.";
                case "GORDIUS":
                    return "Gordius";
                case "GOULD":
                    return "Gould";
                case "HAGIWARA":
                    return "Hagiwara Sys-Com Co., Ltd.";
                case "HAPP3":
                    return "Inventec Multimedia and Telecom co., ltd";
                case "HDS":
                    return "Horizon Data Systems, Inc.";
                case "Heydays":
                    return "Mazo Technology Co., Ltd.";
                case "HI-TECH":
                    return "HI-TECH Software Pty. Ltd.";
                case "HITACHI":
                    return "Hitachi America Ltd or Nissei Sangyo America Ltd";
                case "HL-DT-ST":
                    return "Hitachi-LG Data Storage, Inc.";
                case "HONEYWEL":
                    return "Honeywell Inc.";
                case "HP":
                    return "Hewlett Packard";
                case "HPQ":
                    return "Hewlett Packard";
                case "HYUNWON":
                    return "HYUNWON inc";
                case "i-cubed":
                    return "i-cubed ltd.";
                case "IBM":
                    return "International Business Machines";
                case "ICL":
                    return "ICL";
                case "ICP":
                    return "ICP vortex Computersysteme GmbH";
                case "IDE":
                    return "International Data Engineering, Inc.";
                case "IDG":
                    return "Interface Design Group";
                case "IET":
                    return "ISCSI ENTERPRISE TARGET";
                case "IFT":
                    return "Infortrend Technology, Inc.";
                case "IGR":
                    return "Intergraph Corp.";
                case "IMATION":
                    return "Imation";
                case "IMPLTD":
                    return "Integrated Micro Products Ltd.";
                case "IMPRIMIS":
                    return "Imprimis Technology Inc.";
                case "INCIPNT":
                    return "Incipient Technologies Inc.";
                case "INCITS":
                    return "InterNational Committee for Information Technology";
                case "INDCOMP":
                    return "Industrial Computing Limited";
                case "Indigita":
                    return "Indigita Corporation";
                case "INITIO":
                    return "Initio Corporation";
                case "INRANGE":
                    return "INRANGE Technologies Corporation";
                case "INSITE":
                    return "Insite Peripherals";
                case "integrix":
                    return "Integrix, Inc.";
                case "INTEL":
                    return "Intel Corporation";
                case "Intransa":
                    return "Intransa, Inc.";
                case "IOC":
                    return "I/O Concepts, Inc.";
                case "iofy":
                    return "iofy Corporation";
                case "IOMEGA":
                    return "Iomega";
                case "iqstor":
                    return "iQstor Networks, Inc.";
                case "iQue":
                    return "iQue";
                case "ISi":
                    return "Information Storage inc.";
                case "Isilon":
                    return "Isilon Systems, Inc.";
                case "ISO":
                    return "International Standards Organization";
                case "iStor":
                    return "iStor Networks, Inc.";
                case "ITC":
                    return "International Tapetronics Corporation";
                case "IVIVITY":
                    return "iVivity, Inc.";
                case "IVMMLTD":
                    return "InnoVISION Multimedia Ltd.";
                case "JABIL001":
                    return "Jabil Circuit";
                case "JETWAY":
                    return "Jetway Information Co., Ltd";
                case "JPC Inc.":
                    return "JPC Inc.";
                case "JSCSI":
                    return "jSCSI Project";
                case "JVC":
                    return "JVC Information Products Co.";
                case "KASHYA":
                    return "Kashya, Inc.";
                case "KENNEDY":
                    return "Kennedy Company";
                case "KENWOOD":
                    return "KENWOOD Corporation";
                case "KEWL":
                    return "Shanghai KEWL Imp&Exp Co., Ltd.";
                case "KMNRIO":
                    return "Kaminario Technologies Ltd.";
                case "KODAK":
                    return "Eastman Kodak";
                case "KONAN":
                    return "Konan";
                case "koncepts":
                    return "koncepts International Ltd.";
                case "KONICA":
                    return "Konica Japan";
                case "KSCOM":
                    return "KSCOM Co. Ltd.,";
                case "KUDELSKI":
                    return "Nagravision SA - Kudelski Group";
                case "Kyocera":
                    return "Kyocera Corporation";
                case "LAPINE":
                    return "Lapine Technology";
                case "LASERDRV":
                    return "LaserDrive Limited";
                case "LASERGR":
                    return "Lasergraphics, Inc.";
                case "LeapFrog":
                    return "LeapFrog Enterprises, Inc.";
                case "LEFTHAND":
                    return "LeftHand Networks (now HP)";
                case "Leica":
                    return "Leica Camera AG";
                case "Lexar":
                    return "Lexar Media, Inc.";
                case "LEYIO":
                    return "LEYIO";
                case "LG":
                    return "LG Electronics Inc.";
                case "LGE":
                    return "LG Electronics Inc.";
                case "LION":
                    return "Lion Optics Corporation";
                case "LMS":
                    return "Laser Magnetic Storage International Company";
                case "LoupTech":
                    return "Loup Technologies, Inc.";
                case "LSI":
                    return "LSI Corp. (was LSI Logic Corp.)";
                case "LSILOGIC":
                    return "LSI Logic Storage Systems, Inc.";
                case "LTO-CVE":
                    return "Linear Tape - Open, Compliance Verification Entity";
                case "LUXPRO":
                    return "Luxpro Corporation";
                case "Malakite":
                    return "Malachite Technologies";
                case "MarcBoon":
                    return "marcboon.com";
                case "Marner":
                    return "Marner Storage Technologies, Inc.";
                case "MARVELL":
                    return "Marvell Semiconductor, Inc.";
                case "MATSHITA":
                    return "Matsushita";
                case "MAXELL":
                    return "Hitachi Maxell, Ltd.";
                case "MAXIM-IC":
                    return "Maxim Integrated Products";
                case "MaxOptix":
                    return "Maxoptix Corp.";
                case "MAXSTRAT":
                    return "Maximum Strategy, Inc.";
                case "MAXTOR":
                    return "Maxtor Corp.";
                case "MaXXan":
                    return "MaXXan Systems, Inc.";
                case "MAYCOM":
                    return "maycom Co., Ltd.";
                case "MBEAT":
                    return "K-WON C&C Co.,Ltd";
                case "MCC":
                    return "Measurement Computing Corporation";
                case "McDATA":
                    return "McDATA Corporation";
                case "MDI":
                    return "Micro Design International, Inc.";
                case "MEADE":
                    return "Meade Instruments Corporation";
                case "mediamat":
                    return "mediamatic";
                case "MEII":
                    return "Mountain Engineering II, Inc.";
                case "MELA":
                    return "Mitsubishi Electronics America";
                case "MELCO":
                    return "Mitsubishi Electric (Japan)";
                case "mellanox":
                    return "Mellanox Technologies Ltd.";
                case "MEMOREX":
                    return "Memorex Telex Japan Ltd.";
                case "MEMREL":
                    return "Memrel Corporation";
                case "MEMTECH":
                    return "MemTech Technology";
                case "MendoCno":
                    return "Mendocino Software";
                case "MERIDATA":
                    return "Oy Meridata Finland Ltd";
                case "METRUM":
                    return "Metrum, Inc.";
                case "MHTL":
                    return "Matsunichi Hi-Tech Limited";
                case "MICROBTX":
                    return "Microbotics Inc.";
                case "Microchp":
                    return "Microchip Technology, Inc.";
                case "MICROLIT":
                    return "Microlite Corporation";
                case "MICROP":
                    return "Micropolis";
                case "MICROTEK":
                    return "Microtek Storage Corp";
                case "Minitech":
                    return "Minitech (UK) Limited";
                case "Minolta":
                    return "Minolta Corporation";
                case "MINSCRIB":
                    return "Miniscribe";
                case "MiraLink":
                    return "MiraLink Corporation";
                case "MITSUMI":
                    return "Mitsumi Electric Co., Ltd.";
                case "MKM":
                    return "Mitsubishi Kagaku Media Co., LTD.";
                case "Mobii":
                    return "Mobii Systems (Pty.) Ltd.";
                case "MOL":
                    return "Petrosoft Sdn. Bhd.";
                case "MOSAID":
                    return "Mosaid Technologies Inc.";
                case "MOTOROLA":
                    return "Motorola";
                case "MP-400":
                    return "Daiwa Manufacturing Limited";
                case "MPC":
                    return "MPC Corporation";
                case "MPCCORP":
                    return "MPC Computers";
                case "MPEYE":
                    return "Touchstone Technology Co., Ltd";
                case "MPIO":
                    return "DKT Co.,Ltd";
                case "MPM":
                    return "Mitsubishi Paper Mills, Ltd.";
                case "MPMan":
                    return "MPMan.com, Inc.";
                case "MSFT":
                    return "Microsoft Corporation";
                case "MSI":
                    return "Micro-Star International Corp.";
                case "MST":
                    return "Morning Star Technologies, Inc.";
                case "MSystems":
                    return "M-Systems Flash Disk Pioneers";
                case "MTI":
                    return "MTI Technology Corporation";
                case "MTNGATE":
                    return "MountainGate Data Systems";
                case "MXI":
                    return "Memory Experts International";
                case "nac":
                    return "nac Image Technology Inc.";
                case "NAGRA":
                    return "Nagravision SA - Kudelski Group";
                case "NAI":
                    return "North Atlantic Industries";
                case "NAKAMICH":
                    return "Nakamichi Corporation";
                case "NatInst":
                    return "National Instruments";
                case "NatSemi":
                    return "National Semiconductor Corp.";
                case "NCITS":
                    return "InterNational Committee for Information Technology Standards";
                case "NCL":
                    return "NCL America";
                case "NCR":
                    return "NCR Corporation";
                case "Neartek":
                    return "Neartek, Inc.";
                case "NEC":
                    return "NEC";
                case "NETAPP":
                    return "NetApp, Inc. (was Network Appliance)";
                case "NetBSD":
                    return "The NetBSD Foundation";
                case "Netcom":
                    return "Netcom Storage";
                case "NETENGIN":
                    return "NetEngine, Inc.";
                case "NEWISYS":
                    return "Newisys Data Storage";
                case "Newtech":
                    return "Newtech Co., Ltd.";
                case "NEXSAN":
                    return "Nexsan Technologies, Ltd.";
                case "NHR":
                    return "NH Research, Inc.";
                case "Nimble":
                    return "Nimble Storage";
                case "NISCA":
                    return "NISCA Inc.";
                case "NISHAN":
                    return "Nishan Systems Inc.";
                case "NKK":
                    return "NKK Corp.";
                case "NRC":
                    return "Nakamichi Research Corporation";
                case "NSD":
                    return "Nippon Systems Development Co.,Ltd.";
                case "NSM":
                    return "NSM Jukebox GmbH";
                case "nStor":
                    return "nStor Technologies, Inc.";
                case "NT":
                    return "Northern Telecom";
                case "NUCONNEX":
                    return "NuConnex";
                case "NUSPEED":
                    return "NuSpeed, Inc.";
                case "NVIDIA":
                    return "NVIDIA Corporation";
                case "OAI":
                    return "Optical Access International";
                case "OCE":
                    return "Oce Graphics";
                case "OHDEN":
                    return "Ohden Co., Ltd.";
                case "OKI":
                    return "OKI Electric Industry Co.,Ltd (Japan)";
                case "Olidata":
                    return "Olidata S.p.A.";
                case "OMI":
                    return "Optical Media International";
                case "OMNIFI":
                    return "Rockford Corporation - Omnifi Media";
                case "OMNIS":
                    return "OMNIS Company (FRANCE)";
                case "Ophidian":
                    return "Ophidian Designs";
                case "Optelec":
                    return "Optelec BV";
                case "Optiarc":
                    return "Sony Optiarc Inc.";
                case "OPTIMEM":
                    return "Cipher/Optimem";
                case "OPTOTECH":
                    return "Optotech";
                case "ORANGE":
                    return "Orange Micro, Inc.";
                case "ORCA":
                    return "Orca Technology";
                case "OSI":
                    return "Optical Storage International";
                case "OSNEXUS":
                    return "OS NEXUS, Inc.";
                case "OTL":
                    return "OTL Engineering";
                case "OVERLAND":
                    return "Overland Storage Inc.";
                case "pacdigit":
                    return "Pacific Digital Corp";
                case "Packard":
                    return "Parkard Bell";
                case "Panasas":
                    return "Panasas, Inc.";
                case "PARALAN":
                    return "Paralan Corporation";
                case "PASCOsci":
                    return "Pasco Scientific";
                case "PATHLGHT":
                    return "Pathlight Technology, Inc.";
                case "PerStor":
                    return "Perstor";
                case "PERTEC":
                    return "Pertec Peripherals Corporation";
                case "PFTI":
                    return "Performance Technology Inc.";
                case "PFU":
                    return "PFU Limited";
                case "PHILIPS":
                    return "Philips Electronics";
                case "PICO":
                    return "Packard Instrument Company";
                case "PIK":
                    return "TECHNILIENT & MCS";
                case "Pillar":
                    return "Pillar Data Systems";
                case "PIONEER":
                    return "Pioneer Electronic Corp.";
                case "Pirus":
                    return "Pirus Networks";
                case "PIVOT3":
                    return "Pivot3, Inc.";
                case "PLASMON":
                    return "Plasmon Data";
                case "Pliant":
                    return "Pliant Technology, Inc.";
                case "PMCSIERA":
                    return "PMC-Sierra";
                case "POKEN":
                    return "Poken SA";
                case "POLYTRON":
                    return "PT. HARTONO ISTANA TEKNOLOGI";
                case "PRAIRIE":
                    return "PrairieTek";
                case "PREPRESS":
                    return "PrePRESS Solutions";
                case "PRESOFT":
                    return "PreSoft Architects";
                case "PRESTON":
                    return "Preston Scientific";
                case "PRIAM":
                    return "Priam";
                case "PRIMAGFX":
                    return "Primagraphics Ltd";
                case "PROCOM":
                    return "Procom Technology";
                case "PROMISE":
                    return "PROMISE TECHNOLOGY, Inc";
                case "PROSTOR":
                    return "ProStor Systems, Inc.";
                case "PTI":
                    return "Peripheral Technology Inc.";
                case "PTICO":
                    return "Pacific Technology International";
                case "QIC":
                    return "Quarter-Inch Cartridge Drive Standards, Inc.";
                case "QLogic":
                    return "QLogic Corporation";
                case "Qsan":
                    return "QSAN Technology, Inc.";
                case "QUALSTAR":
                    return "Qualstar";
                case "QUANTEL":
                    return "Quantel Ltd.";
                case "QUANTUM":
                    return "Quantum Corp.";
                case "QUIX":
                    return "Quix Computerware AG";
                case "R-BYTE":
                    return "R-Byte, Inc.";
                case "RACALREC":
                    return "Racal Recorders";
                case "RADITEC":
                    return "Radikal Technologies Deutschland GmbH";
                case "RADSTONE":
                    return "Radstone Technology";
                case "RASVIA":
                    return "Rasvia Systems, Inc.";
                case "rave-mp":
                    return "Go Video";
                case "Readboy":
                    return "Readboy Ltd Co.";
                case "Realm":
                    return "Realm Systems";
                case "RELDATA":
                    return "RELDATA Inc";
                case "RENAGmbH":
                    return "RENA GmbH";
                case "Revivio":
                    return "Revivio, Inc.";
                case "RGI":
                    return "Raster Graphics, Inc.";
                case "RHAPSODY":
                    return "Rhapsody Networks, Inc.";
                case "RHS":
                    return "Racal-Heim Systems GmbH";
                case "RICOH":
                    return "Ricoh";
                case "RODIME":
                    return "Rodime";
                case "Royaltek":
                    return "RoyalTek company Ltd.";
                case "RPS":
                    return "RPS";
                case "RTI":
                    return "Reference Technology";
                case "S-D":
                    return "Sauer-Danfoss";
                case "SAMSUNG":
                    return "Samsung Electronics Co., Ltd.";
                case "SAN":
                    return "Storage Area Networks, Ltd.";
                case "Sandial":
                    return "Sandial Systems, Inc.";
                case "SanDisk":
                    return "SanDisk Corporation";
                case "SANKYO":
                    return "Sankyo Seiki";
                case "SANRAD":
                    return "SANRAD Inc.";
                case "SANYO":
                    return "SANYO Electric Co., Ltd.";
                case "SC.Net":
                    return "StorageConnections.Net";
                case "SCALE":
                    return "Scale Computing, Inc.";
                case "SCIENTEK":
                    return "SCIENTEK CORP";
                case "SCInc.":
                    return "Storage Concepts, Inc.";
                case "SCREEN":
                    return "Dainippon Screen Mfg. Co., Ltd.";
                case "SDI":
                    return "Storage Dimensions, Inc.";
                case "SDS":
                    return "Solid Data Systems";
                case "SEAC":
                    return "SeaChange International, Inc.";
                case "SEAGATE":
                    return "Seagate";
                case "SEAGRAND":
                    return "SEAGRAND In Japan";
                case "Seanodes":
                    return "Seanodes";
                case "Sec. Key":
                    return "SecureKey Technologies Inc.";
                case "SEQUOIA":
                    return "Sequoia Advanced Technologies, Inc.";
                case "Shinko":
                    return "Shinko Electric Co., Ltd.";
                case "SIEMENS":
                    return "Siemens";
                case "SigmaTel":
                    return "SigmaTel, Inc.";
                case "SII":
                    return "Seiko Instruments Inc.";
                case "SIMPLE":
                    return "SimpleTech, Inc. (Obs - now STEC, Inc.)";
                case "SLCNSTOR":
                    return "SiliconStor, Inc.";
                case "SLI":
                    return "Sierra Logic, Inc.";
                case "SMS":
                    return "Scientific Micro Systems/OMTI";
                case "SMX":
                    return "Smartronix, Inc.";
                case "SNYSIDE":
                    return "Sunnyside Computing Inc.";
                case "SoftLock":
                    return "Softlock Digital Security Provider";
                case "SONIC":
                    return "Sonic Solutions";
                case "SoniqCas":
                    return "SoniqCast";
                case "SONY":
                    return "Sony Corporation Japan";
                case "SPD":
                    return "Storage Products Distribution, Inc.";
                case "SPECIAL":
                    return "Special Computing Co.";
                case "SPECTRA":
                    return "Spectra Logic, a Division of Western Automation Labs, Inc.";
                case "SPERRY":
                    return "Sperry (now Unisys Corp.)";
                case "Spintso":
                    return "Spintso International AB";
                case "STEC":
                    return "STEC, Inc.";
                case "Sterling":
                    return "Sterling Diagnostic Imaging, Inc.";
                case "STK":
                    return "Storage Technology Corporation";
                case "STNWOOD":
                    return "Stonewood Group";
                case "STONEFLY":
                    return "StoneFly Networks, Inc.";
                case "STOR":
                    return "StorageNetworks, Inc.";
                case "STORAPP":
                    return "StorageApps, Inc. (now HP)";
                case "STORCOMP":
                    return "Storage Computer Corporation";
                case "STORM":
                    return "Storm Technology, Inc.";
                case "StorMagc":
                    return "StorMagic";
                case "Stratus":
                    return "Stratus Technologies";
                case "StrmLgc":
                    return "StreamLogic Corp.";
                case "SUMITOMO":
                    return "Sumitomo Electric Industries, Ltd.";
                case "SUN":
                    return "Sun Microsystems, Inc.";
                case "SUNCORP":
                    return "SunCorporation";
                case "suntx":
                    return "Suntx System Co., Ltd";
                case "Swinxs":
                    return "Swinxs BV";
                case "SYMANTEC":
                    return "Symantec Corporation";
                case "SYMBIOS":
                    return "Symbios Logic Inc.";
                case "SYMWAVE":
                    return "Symwave, Inc.";
                case "SYNERWAY":
                    return "Synerway";
                case "SyQuest":
                    return "SyQuest Technology, Inc.";
                case "SYSGEN":
                    return "Sysgen";
                case "T-MITTON":
                    return "Transmitton England";
                case "T-MOBILE":
                    return "T-Mobile USA, Inc.";
                case "T11":
                    return "INCITS Technical Committee T11";
                case "TALARIS":
                    return "Talaris Systems, Inc.";
                case "TALLGRAS":
                    return "Tallgrass Technologies";
                case "TANDBERG":
                    return "Tandberg Data A/S";
                case "TANDEM":
                    return "Tandem (now HP)";
                case "TANDON":
                    return "Tandon";
                case "TCL":
                    return "TCL Shenzhen ASIC MIcro-electronics Ltd";
                case "TDK":
                    return "TDK Corporation";
                case "TEAC":
                    return "TEAC Japan";
                case "TECOLOTE":
                    return "Tecolote Designs";
                case "TEGRA":
                    return "Tegra Varityper";
                case "Tek":
                    return "Tektronix";
                case "TELLERT":
                    return "Tellert Elektronik GmbH";
                case "TENTIME":
                    return "Laura Technologies, Inc.";
                case "Test":
                    return "Test new Vendor ID software - delete me!";
                case "TFDATACO":
                    return "TimeForge";
                case "TGEGROUP":
                    return "TGE Group Co.,LTD.";
                case "TI-DSG":
                    return "Texas Instruments";
                case "TiGi":
                    return "TiGi Corporation";
                case "TILDESGN":
                    return "Tildesign bv";
                case "Tite":
                    return "Tite Technology Limited";
                case "TMS":
                    return "Texas Memory Systems, Inc.";
                case "TMS100":
                    return "TechnoVas";
                case "TOLISGRP":
                    return "The TOLIS Group";
                case "TOSHIBA":
                    return "Toshiba Japan";
                case "TRIPACE":
                    return "Tripace";
                case "TRLogger":
                    return "TrueLogger Ltd.";
                case "TROIKA":
                    return "Troika Networks, Inc.";
                case "TRULY":
                    return "TRULY Electronics MFG. LTD.";
                case "TRUSTED":
                    return "Trusted Data Corporation";
                case "TSSTcorp":
                    return "Toshiba Samsung Storage Technology Corporation";
                case "TZM":
                    return "TZ Medical";
                case "UDIGITAL":
                    return "United Digital Limited";
                case "UIT":
                    return "United Infomation Technology";
                case "ULTRA":
                    return "UltraStor Corporation";
                case "UNISYS":
                    return "Unisys";
                case "USCORE":
                    return "Underscore, Inc.";
                case "USDC":
                    return "US Design Corp.";
                case "VDS":
                    return "Victor Data Systems Co., Ltd.";
                case "Verari":
                    return "Verari Systems, Inc.";
                case "VERBATIM":
                    return "Verbatim Corporation";
                case "Vercet":
                    return "Vercet LLC";
                case "VERITAS":
                    return "VERITAS Software Corporation";
                case "VEXCEL":
                    return "VEXCEL IMAGING GmbH";
                case "VicomSys":
                    return "Vicom Systems, Inc.";
                case "VIDEXINC":
                    return "Videx, Inc.";
                case "VITESSE":
                    return "Vitesse Semiconductor Corporation";
                case "VIXEL":
                    return "Vixel Corporation (now part of Emulex)";
                case "VLS":
                    return "Van Lent Systems BV";
                case "VMAX":
                    return "VMAX Technologies Corp.";
                case "Vobis":
                    return "Vobis Microcomputer AG";
                case "VOLTAIRE":
                    return "Voltaire Ltd.";
                case "VRC":
                    return "Vermont Research Corp.";
                case "VRugged":
                    return "Vanguard Rugged Storage";
                case "Waitec":
                    return "Waitec NV";
                case "WangDAT":
                    return "WangDAT";
                case "WANGTEK":
                    return "Wangtek";
                case "Wasabi":
                    return "Wasabi Systems";
                case "WAVECOM":
                    return "Wavecom";
                case "WD":
                    return "Western Digital Technologies Inc.";
                case "WDC":
                    return "Western Digital Technologies inc.";
                case "WDIGTL":
                    return "Western Digital";
                case "WEARNES":
                    return "Wearnes Technology Corporation";
                case "WSC0001":
                    return "Wisecom, Inc.";
                case "X3":
                    return "International Committee for Information Technology Standards)";
                case "XEBEC":
                    return "Xebec Corporation";
                case "XENSRC":
                    return "XenSource, Inc.";
                case "Xerox":
                    return "Xerox Corporation";
                case "XIOtech":
                    return "XIOtech Corporation";
                case "XIRANET":
                    return "Xiranet Communications GmbH";
                case "XIV":
                    return "XIV (now IBM)";
                case "XYRATEX":
                    return "Xyratex";
                case "YINHE":
                    return "NUDT Computer Co.";
                case "YIXUN":
                    return "Yixun Electronic Co.,Ltd.";
                case "YOTTA":
                    return "YottaYotta, Inc.";
                case "Zarva":
                    return "Zarva Digital Technology Co., Ltd.";
                case "ZETTA":
                    return "Zetta Systems, Inc.";
                default:
                    return null;
            }
        }
    }
}
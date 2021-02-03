using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Juno.Sdk.Services
{
    public class JunoServices
    {
        public JunoServices(
            AdditionalDataService additionalData,
            BalancesService balances,
            ChargesService charges,
            DigitalAccountsService digitalAccounts,
            DocumentsService documents,
            NotificationsService notifications,
            PaymentsService payments,
            PublicKeysService publicKeys,
            TransfersService transfers)
        {
            AdditionalData = additionalData;
            Balances = balances;
            Charges = charges;
            DigitalAccounts = digitalAccounts;
            Documents = documents;
            Notifications = notifications;
            Payments = payments;
            PublicKeys = publicKeys;
            Transfers = transfers;
        }

        public AdditionalDataService AdditionalData { get; }

        public BalancesService Balances { get; }

        public ChargesService Charges { get; }

        public DigitalAccountsService DigitalAccounts { get; }

        public DocumentsService Documents { get; }

        public NotificationsService Notifications { get; }

        public PaymentsService Payments { get; }

        public PublicKeysService PublicKeys { get; }

        public TransfersService Transfers { get; }
    }
}

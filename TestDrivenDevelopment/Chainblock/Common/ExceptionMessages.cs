
namespace Chainblock.Common
{
   public static class ExceptionMessages
    {
        public static string InvalidIdMessage = "IDs cannot be zero or negative!";

        public static string InvalidSenderUserNameMessage = "Sender name cannot be empty ot whitespace!";

        public static string InvalidReceiverUserNameMessage = "Receiver name cannot be empty ot whitespace!";

        public static string InvalidAmountMessage = "Amount cannot be zero ot negative!";


        public static string AddingExistingIdTransactionMessage = "This id is already existing!";

        public static string ContainsNullExceptionMessage = "The transaction cannot be null!";

        public static string ChangeStatusToNotExistingIDMessage = "Cannot change transaction status to not existing transaction! This transaction's Id is not found!";

        public static string RemoveByIdNotExistingIdMessage = "Cannot remove a not existing transaction! This transaction's Id is not found! ";

        public static string GetByIDNonExistingIDMessage = "This trasnsaction's Id is not found!";

        public static string GetByTransactionStatusNonExistingStatusMessage = "Trnasactions with this status not exist!";

        public static string GetAllSendersWithNonExistingTransactionStatusMessage = "There are no senders with this transaction status!";

        public static string GetAllReceiversWithNonExistingTransactionStatusMessage = "There are no receivers with this transaction status!";

        public static string EmptyChainblockMessage = "The chainblock is empty!";

        public static string GetBySenderOrderedByAmountDescendingExceptionMessage = "There are no transactions with this sender!";

        public static string GetByReceiverOrderedByAmountThenByIdExceptionMessage =
            "There are no transactions with this receiver!";

        public static string GetBySenderAndMinimumAmountDescendingExceptionMessage =
            "No matches found for this sender and this minimum amount!";

        public static string GetByReceiverAndAmountRangeExceptionMessage = "No matches found  in the given range of amounts with the given receiver!";
    }
}

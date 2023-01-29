// O(n^2) :/

struct buyingState
{
    bool isBought;
    int currentPrice;
    int day;
    int currentProfit;
    bool cd;
    buyingState(bool isBought, int currentPrice,int currentProfit, int day,  bool cd)
    {
        this->isBought=isBought;
        this->currentPrice=currentPrice;
        this->day=day;
        this->currentProfit=currentProfit;
        this->cd=cd;
    }
};

class Solution {
public:
    int maxProfit(const vector<int>& prices) {
        profit=0;
        if (prices.size()==1) return 0;
        solve.push(buyingState(0,0,0,0,0));
        while (!solve.empty())
        {
            operation(prices,solve.front());
            solve.pop();
        }
        return profit;
    }
private:
    int profit;
    queue <buyingState> solve;
    void operation(const vector<int>& prices, buyingState& state)
    {
        if (state.day==prices.size()-1)
        {
            if (state.isBought) state.currentProfit+=prices[state.day]-state.currentPrice;
            if (profit<state.currentProfit) profit=state.currentProfit;
            return;
        }
        if (state.cd)
        {
            solve.push(buyingState(0,0,state.currentProfit,state.day+1,0));
            return;
        }
        if (state.isBought==false && profit>state.currentProfit) return; // = ???
        if (profit<state.currentProfit && state.currentProfit>0) profit=state.currentProfit;
        if (!state.isBought)
        {
            if (prices[state.day]<prices[state.day+1]) solve.push(buyingState(1,prices[state.day],state.currentProfit,state.day+1,false));
            solve.push(buyingState(false,state.currentPrice,state.currentProfit,state.day+1,false));
        }
        if (state.isBought)
        {
            if (state.day==prices.size()-2) solve.push(buyingState(false,0,state.currentProfit+prices[state.day]-state.currentPrice,state.day+1,true));
            else if (prices[state.day]>state.currentPrice && (state.day<=(prices.size()-3))) solve.push(buyingState(false,0,state.currentProfit+prices[state.day]-state.currentPrice,state.day+1,true));
            solve.push(buyingState(true,state.currentPrice,state.currentProfit,state.day+1,false)); 
        }
    }
};
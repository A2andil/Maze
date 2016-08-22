//In The Name of Allah
#include <iostream>
#include<queue>
#include<stack>
using namespace std;

struct CurST{
    int State[3][3];
    CurST* Parent;
};
int stat[3][3],Goal[3][3]={{1,2,3},
                           {4,5,6},
                           {7,8,0}};
class BFS{
private:
    int index=0;
    CurST* visted[100005];
    stack<CurST*> S;
public:
    int cost=0;
    queue<CurST*> Q;
    CurST* intial;
    BFS(){
        intial = new CurST();
        for(int i=0;i<3;i++)
            for(int j=0;j<3;j++)
                intial->State[i][j]=stat[i][j];
        intial->Parent=NULL;
        Q.push(intial);
        visted[index++]=intial;
    }

    void StartSolution(){
        while(!Q.empty()){
            CurST* current=Q.front();
            if(IsGoal(current)){
                //here cost
                int Cst=Cost(current);
                cout<<"Quantidade minima de passos = "<<Cst<<endl;
                while(!S.empty()){
                    CurST* Tp=S.top();
                    for(int i=0;i<3;i++){
                        for(int j=0;j<3;j++)
                            cout<<Tp->State[i][j];
                        cout<<endl;
                    }
                    S.pop();
                    if(!S.empty())
                       cout<<endl;
                }
                break;
            }
            else{
                int x,y;
                for(int i=0;i<3;i++)
                    for(int j=0;j<3;j++)
                        if(current->State[i][j]==0){
                          x=i,y=j;
                          break;
                        }
                Getchild(current,x,y);
                Q.pop();
            }
        }
    }

    int Cost(CurST* ptr){
        int cst=0;
        CurST* cur=ptr;
        while(cur->Parent!=NULL){
            cst++;
            S.push(cur);
            cur=cur->Parent;
        }
        return cst;
    }

    bool IsGoal(CurST* ptr){
        int cnt=0;
        for(int i=0;i<3;i++)
            for(int j=0;j<3;j++)
                if(ptr->State[i][j]==Goal[i][j])
                    cnt++;
        if(cnt==9) return true;
        return false;
    }

    void Getchild(CurST* ptr,int x,int y){
        //left
        if(y>0){
            CurST* LF=new CurST();
            LF->Parent=ptr;
            for(int i=0;i<3;i++)
                for(int j=0;j<3;j++){
                    LF->State[i][j]=ptr->State[i][j];
                }
            LF->State[x][y]=LF->State[x][y-1];
            LF->State[x][y-1]=0;
            if(!isVisted(LF)){
                Q.push(LF);
                visted[index++]=LF;
            }
        }
        //right
        if(y<2){
            CurST *RT=new CurST();
            RT->Parent=ptr;
            for(int i=0;i<3;i++)
                for(int j=0;j<3;j++){
                    RT->State[i][j]=ptr->State[i][j];
                }
            RT->State[x][y]=RT->State[x][y+1];
            RT->State[x][y+1]=0;
            if(!isVisted(RT)){
                Q.push(RT);
                 visted[index++]=RT;
            }
        }
       //top
        if(x>0){
            CurST* TP=new CurST();
            TP->Parent=ptr;
            for(int i=0;i<3;i++)
                for(int j=0;j<3;j++){
                    TP->State[i][j]=ptr->State[i][j];
                }
            TP->State[x][y]=TP->State[x-1][y];
            TP->State[x-1][y]=0;
            if(!isVisted(TP)){
                Q.push(TP);
                visted[index++]=TP;
            }
        }
       //bottom
        if(x<2){
            CurST* BT=new CurST();
            BT->Parent=ptr;
            for(int i=0;i<3;i++)
                for(int j=0;j<3;j++){
                    BT->State[i][j]=ptr->State[i][j];
                }
            BT->State[x][y]=BT->State[x+1][y];
            BT->State[x+1][y]=0;
            if(!isVisted(BT)){
                Q.push(BT);
                visted[index++]=BT;
            }
        }
    }

    bool isVisted(CurST* ptr){
        bool rs=false;
        for(int i=0;i<index;i++){
            int cnt=0;
            for(int n=0;n<3;n++)
                for(int m=0;m<3;m++){
                    if(ptr->State[n][m]==visted[i]->State[n][m])
                        cnt++;
                }

            if(cnt==9){
                rs=true;
                break;
            }
        }
        return rs;

    }
};

int main(){
    string v;
    int cnt=0;
    while(getline(cin,v)){
        stat[cnt][0]=v[0]-48;
        stat[cnt][1]=v[1]-48;
        stat[cnt][2]=v[2]-48;
        cnt++;
        if(cnt==3){
            BFS* bfs=new BFS();
            bfs->StartSolution();
            cnt=0;
        }

    }
    return 0;
}

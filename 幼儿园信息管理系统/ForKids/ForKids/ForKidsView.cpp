// ��� MFC ʾ��Դ������ʾ���ʹ�� MFC Microsoft Office Fluent �û����� 
// (��Fluent UI��)����ʾ�������ο���
// ���Բ��䡶Microsoft ������ο����� 
// MFC C++ ������渽����ص����ĵ���
// ���ơ�ʹ�û�ַ� Fluent UI ����������ǵ����ṩ�ġ�
// ��Ҫ�˽��й� Fluent UI ��ɼƻ�����ϸ��Ϣ�������  
// http://msdn.microsoft.com/officeui��
//
// ��Ȩ����(C) Microsoft Corporation
// ��������Ȩ����

// ForKidsView.cpp : CForKidsView ���ʵ��
//

#include "stdafx.h"
// SHARED_HANDLERS ������ʵ��Ԥ��������ͼ������ɸѡ�������
// ATL ��Ŀ�н��ж��壬�����������Ŀ�����ĵ����롣
#ifndef SHARED_HANDLERS
#include "ForKids.h"
#endif

#include "ForKidsDoc.h"
#include "ForKidsView.h"

using namespace ForKids::UI;

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


// CForKidsView

IMPLEMENT_DYNCREATE(CForKidsView, CView)

BEGIN_MESSAGE_MAP(CForKidsView, CView)
	// ��׼��ӡ����
	ON_COMMAND(ID_FILE_PRINT, &CView::OnFilePrint)
	ON_COMMAND(ID_FILE_PRINT_DIRECT, &CView::OnFilePrint)
	ON_COMMAND(ID_FILE_PRINT_PREVIEW, &CForKidsView::OnFilePrintPreview)
	ON_WM_CONTEXTMENU()
	ON_WM_RBUTTONUP()
	ON_WM_SIZE()
END_MESSAGE_MAP()

// CForKidsView ����/����

CForKidsView::CForKidsView():m_bLoadMainPanel(FALSE)
{
	// TODO: �ڴ˴���ӹ������

}

CForKidsView::~CForKidsView()
{
}

BOOL CForKidsView::PreCreateWindow(CREATESTRUCT& cs)
{
	// TODO: �ڴ˴�ͨ���޸�
	//  CREATESTRUCT cs ���޸Ĵ��������ʽ

	return CView::PreCreateWindow(cs);
}

// CForKidsView ����

void CForKidsView::OnDraw(CDC* /*pDC*/)
{
	CForKidsDoc* pDoc = GetDocument();
	ASSERT_VALID(pDoc);
	if (!pDoc)
		return;

	// TODO: �ڴ˴�Ϊ����������ӻ��ƴ���
}


// CForKidsView ��ӡ


void CForKidsView::OnFilePrintPreview()
{
#ifndef SHARED_HANDLERS
	AFXPrintPreview(this);
#endif
}

BOOL CForKidsView::OnPreparePrinting(CPrintInfo* pInfo)
{
	// Ĭ��׼��
	return DoPreparePrinting(pInfo);
}

void CForKidsView::OnBeginPrinting(CDC* /*pDC*/, CPrintInfo* /*pInfo*/)
{
	// TODO: ��Ӷ���Ĵ�ӡǰ���еĳ�ʼ������
}

void CForKidsView::OnEndPrinting(CDC* /*pDC*/, CPrintInfo* /*pInfo*/)
{
	// TODO: ��Ӵ�ӡ����е��������
}

void CForKidsView::OnRButtonUp(UINT /* nFlags */, CPoint point)
{
	ClientToScreen(&point);
	OnContextMenu(this, point);
}

void CForKidsView::OnContextMenu(CWnd* /* pWnd */, CPoint point)
{
#ifndef SHARED_HANDLERS
	theApp.GetContextMenuManager()->ShowPopupMenu(IDR_POPUP_EDIT, point.x, point.y, this, TRUE);
#endif
}


// CForKidsView ���

#ifdef _DEBUG
void CForKidsView::AssertValid() const
{
	CView::AssertValid();
}

void CForKidsView::Dump(CDumpContext& dc) const
{
	CView::Dump(dc);
}

CForKidsDoc* CForKidsView::GetDocument() const // �ǵ��԰汾��������
{
	ASSERT(m_pDocument->IsKindOf(RUNTIME_CLASS(CForKidsDoc)));
	return (CForKidsDoc*)m_pDocument;
}
#endif //_DEBUG


// CForKidsView ��Ϣ�������


void CForKidsView::OnSize(UINT nType, int cx, int cy)
{
	CView::OnSize(nType, cx, cy);

	// TODO: �ڴ˴������Ϣ����������
	if(this->m_hWnd!=NULL)
	{
		if(!m_bLoadMainPanel)
		{
			m_gcMainPanel = gcnew Panel;
			::SetParent((HWND)m_gcMainPanel->Handle.ToInt32(),this->m_hWnd);
			//DataGridView^ gcDGV = gcnew DataGridView;
			//Label^ gcLabel = gcnew Label;
			//gcLabel->TextAlign = System::Drawing::ContentAlignment::MiddleCenter;
			//gcLabel->Text=L"һ�����ԣ�����һ��C# Label�ؼ���Ƕ���ڻ���C++���Ե�Ribbon���MFC�����ͼ��;����㿴�������ʵ�֣���ô������C#������ɵĹ��ܣ�������Ҳ����ɣ�";
			//gcLabel->AutoSize=FALSE;
			//gcLabel->Font=gcnew System::Drawing::Font(gcLabel->Font->FontFamily,20,System::Drawing::FontStyle::Bold);
			//gcLabel->Dock=DockStyle::Fill;
			//m_gcMainPanel->Controls->Add(gcLabel);

			KidBaseCtrl^ gcCtrl = gcnew KidBaseCtrl;
			gcCtrl->Dock=DockStyle::Fill;
			m_gcMainPanel->Controls->Add(gcCtrl);

			m_bLoadMainPanel=true;
		}
		RECT rect;
		this->GetClientRect(&rect);
		::MoveWindow((HWND)m_gcMainPanel->Handle.ToInt32(),0,0,rect.right,rect.bottom,TRUE);
	}
}

window.renderDashboardCharts = (topNeedsData, campaignStatusData, donationTrendData) => {
    // --- Top Needs Chart ---
    const topNeedsCtx = document.getElementById('topNeedsChart');
    if (topNeedsCtx) {
        new Chart(topNeedsCtx, {
            type: 'bar',
            data: {
                labels: topNeedsData.labels,
                datasets: [{
                    label: 'Funds Collected ($)',
                    data: topNeedsData.values,
                    backgroundColor: '#aed581',
                    borderRadius: 2
                }]
            },
            options: { responsive: true, plugins: { legend: { display: false } } }
        });
    }

    // --- Campaign Status Chart ---
    const campaignStatusCtx = document.getElementById('campaignStatusChart');
    if (campaignStatusCtx) {
        new Chart(campaignStatusCtx, {
            type: 'doughnut',
            data: {
                labels: ['Approved', 'Pending', 'Rejected'],
                datasets: [{
                    data: campaignStatusData,
                    backgroundColor: ['#81c784', '#ffeb3b', '#e57373'],
                    hoverOffset: 10
                }]
            },
            options: { responsive: true, plugins: { legend: { position: 'bottom' } } }
        });
    }

    // --- Donation Trends Line Chart ---
    const donationTrendsCtx = document.getElementById('donationTrendsChart');
    if (donationTrendsCtx) {
        new Chart(donationTrendsCtx, {
            type: 'line',
            data: {
                labels: donationTrendData.labels,
                datasets: [{
                    label: 'Total Donations ($)',
                    data: donationTrendData.values,
                    borderColor: '#4fc3f7',
                    backgroundColor: 'rgba(79,195,247,0.2)',
                    tension: 0.4,
                    fill: true
                }]
            },
            options: { responsive: true }
        });
    }
};
